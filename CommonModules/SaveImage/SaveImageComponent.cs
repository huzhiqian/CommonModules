using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;


//**********************************************
//文件名：SaveImage
//命名空间：CommonModules.SaveImage
//CLR版本：4.0.30319.42000
//内容：保存图片类，实现的保存图片的抽象类
//功能：保存图像基础类，只负责保存bitmap
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/6/19 11:04:39
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.SaveImage
{
    public class SaveImageComponent : ISaveImage
    {
        private bool useCppKernelSave = false;
        private Queue<SaveImageInfo> imageQueue;
        private System.Timers.Timer timer = null;
        private Thread saveImageThread = null;
        //字段
        private string saveRootPath = string.Empty;
        private SaveImageType saveType = SaveImageType.BMP;//默认bmp
        private bool imageNameEndWithTime = false;//图像名称结尾是否添加时间后缀
        private bool isCheckDiskSize = false;//是否检测磁盘容量
        private double allowDiskMinSize = 1.0;//磁盘允许最小容量
        private bool autoCreateDateFolder = false;//是否自动创建日期文件夹
        private bool isSaveImage = true;
        private bool checkNameValidity = false;//检查名称合法性
        private string diskName = string.Empty;//保存图像磁盘名称
        private double diskFreeSpace = 0;//磁盘剩余空间
        #region 构造函数

        public SaveImageComponent()
        {
            //检测当前运行路径下手否存在C++写的保存图像的dll文件
            if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\SaveImageKernel.dll"))
            {
                useCppKernelSave = true;
            }
            else
                useCppKernelSave = false;

            //
            imageQueue = new Queue<SaveImageInfo>();
            timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Elapsed += CheckDiskSizeFunc;
            //配置保存图像参数
            ConfigParam();
            if (!CheckRootPathExit(saveRootPath))
                isSaveImage = false;
            else
            {
                if (isCheckDiskSize)
                {
                    timer.Start();
                }
            }

            saveImageThread = new Thread(SaveImageFunc);
            saveImageThread.IsBackground = true;
            saveImageThread.Start();
        }



        #endregion


        #region 属性

        /// <summary>
        /// 获取或设置保存图像的根目录
        /// </summary>
        [Category("属性")]
        [Browsable(true), ReadOnly(false)]
        [DisplayName("存储根目录"), Description("保存图像的根目录。")]
        public string SaveRootPath
        {
            get { return saveRootPath; }
            set
            {
                if (!value.Equals(saveRootPath))
                {
                    if (CheckRootPathExit(value))
                    {
                        //获取磁盘名
                        diskName = System.IO.Path.GetPathRoot(value);
                        saveRootPath = value;
                        Configer.ConfigHelper.SaveValue("SaveRootPath", value);
                        SaveRootPathChanged?.Invoke(value);
                    }
                    else
                    {
                        SaveRootPathChanged?.Invoke(saveRootPath);
                    }
                }
            }
        }

        /// <summary>
        /// 获取或设置保存图像的类型
        /// </summary>
        [Category("属性")]
        [Browsable(true), ReadOnly(false)]
        [DisplayName("图像类型"), Description("保存图像的类型。")]
        public SaveImageType SaveType
        {
            get { return saveType; }
            set
            {
                if (value != saveType)
                {
                    saveType = value;
                    switch (value)
                    {
                        case SaveImageType.PNG:
                            Configer.ConfigHelper.SaveValue("SaveType", "png");
                            break;
                        case SaveImageType.BMP:
                            Configer.ConfigHelper.SaveValue("SaveType", "bmp");
                            break;
                        case SaveImageType.JPG:
                            Configer.ConfigHelper.SaveValue("SaveType", "jpg");
                            break;
                        default:
                            Configer.ConfigHelper.SaveValue("SaveType", "bmp");
                            break;
                    }

                }
            }
        }

        /// <summary>
        /// 获取或设置图像名加上时间后缀
        /// </summary>
        [Category("属性")]
        [Browsable(true), ReadOnly(false)]
        [DisplayName("图像名加时间戳"), Description("在图像名后面加上时间后缀。")]
        public bool ImageNameEndWithTime
        {
            get { return imageNameEndWithTime; }
            set
            {
                if (value != imageNameEndWithTime)
                {
                    imageNameEndWithTime = value;
                    Configer.ConfigHelper.SaveValue("ImageNameEndWithTime", value);
                }
            }
        }

        /// <summary>
        /// 获取或设置是否检查磁盘容量
        /// </summary>
        [Category("属性")]
        [Browsable(true), ReadOnly(false)]
        [DisplayName("图像名加时间戳"), Description("在图像名后面加上时间后缀。")]
        public bool IsCheckDiskSize
        {
            get { return isCheckDiskSize; }
            set
            {
                if (isCheckDiskSize != value)
                {
                    isCheckDiskSize = value;
                    if (value)
                    {
                        GetDiskFreeSpace();
                        timer.Start();
                    }
                    Configer.ConfigHelper.SaveValue("IsCheckDiskSize", value);
                }
            }
        }

        /// <summary>
        /// 获取或设置磁盘最小允许容量
        /// </summary>
        [Category("属性")]
        [Browsable(true), ReadOnly(false)]
        [DisplayName("允许最小磁盘容量"), Description("允许最小磁盘容量，当磁盘容量低于这个值时将不再保存图片")]
        public double AllowDiskMinSize
        {
            get { return allowDiskMinSize; }
            set
            {
                if (allowDiskMinSize != value)
                {
                    allowDiskMinSize = value;
                    Configer.ConfigHelper.SaveValue("AllowDiskMinSize", value);
                }
            }
        }

        /// <summary>
        /// 获取或设置是否自动创建日期文件夹
        /// </summary>
        [Category("属性")]
        [Browsable(true), ReadOnly(false)]
        [DisplayName("创建时间文件夹"), Description("自动创建时间文件夹")]
        public bool AutoCreateDateFolder
        {
            get { return autoCreateDateFolder; }
            set
            {
                if (autoCreateDateFolder != value)
                {
                    autoCreateDateFolder = value;
                    Configer.ConfigHelper.SaveValue("AutoCreateDateFolder", value);
                }
            }
        }

        /// <summary>
        /// 获取或设置是否保存图像
        /// </summary>
        [Category("属性")]
        [Browsable(true), ReadOnly(false)]
        [DisplayName("是否保存图像"), Description("为TRUE时保存图像，为FALSE时不保存图像")]
        public bool IsSaveImage
        {
            get { return isSaveImage; }
            set
            {
                if (value != isSaveImage)
                {
                    if (value)
                    {
                        if (isCheckDiskSize)//是否检测磁盘容量
                        {
                            timer.Start();
                            if (diskFreeSpace < allowDiskMinSize)
                            {
                                MessageBox.Show("磁盘容量低！", "警告");
                                SaveImageStateChanged?.Invoke(false);
                                return;
                            }
                        }
                        if (CheckRootPathExit(saveRootPath))
                        {
                            isSaveImage = value;
                            Configer.ConfigHelper.SaveValue("IsSaveImage", value);
                            SaveImageStateChanged?.Invoke(true);
                        }
                        else
                            SaveImageStateChanged?.Invoke(false);

                    }
                    else
                    {
                        isSaveImage = value;
                        SaveImageStateChanged?.Invoke(false);
                        Configer.ConfigHelper.SaveValue("IsSaveImage", value);
                        timer.Stop();//停止检测磁盘容量
                    }
                }
            }
        }

        /// <summary>
        /// 获取或设置是否检查图像名称合法性
        /// </summary>
        [Category("属性")]
        [Browsable(true), ReadOnly(false)]
        [DisplayName("检查名称合法性"), Description("保存图片前是否检查图像名称合法性")]
        public bool CheckNameValidity
        {
            get { return checkNameValidity; }
            set
            {
                if (value != checkNameValidity)
                {
                    checkNameValidity = value;
                    Configer.ConfigHelper.SaveValue("CheckNameValidity", value);
                }
            }
        }

        /// <summary>
        /// 获取保存图像的磁盘名
        /// </summary>
        [Category("属性")]
        [Browsable(true), ReadOnly(false)]
        [DisplayName("磁盘名"), Description("保存图像保存到那个磁盘的名称。")]
        public string DiskName
        {
            get { return diskName; }
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 通过保存文件的全名保存图像
        /// </summary>
        /// <param name="image">图像对象</param>
        /// <param name="imagefullName">图像的名称的全名(绝对路径)</param>
        public virtual void SaveImageByFullName(Bitmap image, string imagefullName)
        {
            if (isSaveImage)
            {
                if (imageQueue.Count > 100)
                {
                    CommonModules.Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR,
                        "保存图像队列缓存大于100,将自动丢弃当前图像！");
                    return;
                }
                //保存图像
                SaveImageInfo saveImageInfo = new SaveImageInfo(image, imagefullName);
                imageQueue.Enqueue(saveImageInfo);
            }
        }

        /// <summary>
        /// 保存图像
        /// </summary>
        /// <param name="image">图像对象</param>
        /// <param name="imgName">图形名称</param>
        public virtual void SaveImage(Bitmap image, string imgName)
        {
            if (isSaveImage)
            {
                if (imageQueue.Count > 100)
                {
                    CommonModules.Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR,
                        "保存图像队列缓存大于100,将自动丢弃当前图像！");
                    return;
                }
                //检查名称合法性
                if (checkNameValidity)
                {
                    if (!CheckImageNameValidity(imgName))
                        return;
                }

                string saveFolder = saveRootPath;
                if (autoCreateDateFolder)
                {
                    saveFolder = new StringBuilder(saveRootPath).Append(@"\").Append(DateTime.Now.ToString("yyyy-MM-dd")).ToString();
                    if (!System.IO.Directory.Exists(saveFolder))
                    {
                        System.IO.Directory.CreateDirectory(saveFolder);
                    }
                }
                //生成图像名
                string fullName = MakeImageName(saveFolder, imgName);
                //保存图像
                SaveImageInfo saveImageInfo = new SaveImageInfo(image, fullName);
                imageQueue.Enqueue(saveImageInfo);


            }
        }


        #endregion

        #region 私有方法

        private void CheckDiskSizeFunc(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (isSaveImage)//如果在保存图像则检查磁盘容量
            {

                GetDiskFreeSpace();
                if (diskFreeSpace < allowDiskMinSize)
                {
                    //磁盘空间小于设定允许空间
                    IsSaveImage = false;
                    CommonModules.Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR,
                        $"当前磁盘 {diskName} 剩余空间为{Math.Round(diskFreeSpace, 3)}GB，小于设定的最小允许空间，将不再保存图像，进入图像保存队列的图像将被自动忽略！");
                }
            }
        }

        /// <summary>
        /// 生成新的图像名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual string MakeImageName(string savePath, string name)
        {

            StringBuilder stringBuilder = new StringBuilder(savePath).Append(@"\").Append(name);
            if (imageNameEndWithTime)
            {
                stringBuilder.Append("_").Append(DateTime.Now.ToString("HH-mm-ss-fff"));
            }

            return JudgementImageType(stringBuilder.ToString());
        }

        protected string JudgementImageType(string name)
        {
            StringBuilder stringBuilder = new StringBuilder(name);
            switch (SaveType)
            {
                case SaveImageType.BMP:
                    stringBuilder.Append(".bmp");
                    break;
                case SaveImageType.JPG:
                    stringBuilder.Append(".jpg");
                    break;
                case SaveImageType.PNG:
                    stringBuilder.Append(".png");
                    break;
                default:    //bmp
                    stringBuilder.Append(".bmp");
                    break;
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 检测输入图像名称的合法性
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckImageNameValidity(string name)
        {
            if (name == "" || name == string.Empty)
            {
                Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR, "输入图像名称为空！");
                return false;
            }
            //检测图像名称中是否包含不合法的字符串
            if (name.Contains(" ") || name.Contains("?") || name.Contains(":") ||
                name.Contains("*") || name.Contains("/") || name.Contains(@"\")
                || name.Contains(">") || name.Contains("<") || name.Contains("|") ||
                name.Contains("\""))
            {
                Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR, "图像名称不合法！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 配置参数
        /// </summary>
        protected virtual void ConfigParam()
        {
            saveRootPath = Configer.ConfigHelper.GetValue("SaveRootPath", System.Environment.CurrentDirectory) as string;
            string saveTypeStr = Configer.ConfigHelper.GetValue("SaveType", "bmp") as string;
            switch (saveTypeStr)
            {
                case "bmp":
                    saveType = SaveImageType.BMP;
                    break;
                case "jpg":
                    saveType = SaveImageType.JPG;
                    break;
                case "png":
                    saveType = SaveImageType.PNG;
                    break;
                default:
                    saveType = SaveImageType.BMP;
                    break;
            }
            imageNameEndWithTime = (bool)Configer.ConfigHelper.GetValue("ImageNameEndWithTime", true);
            isCheckDiskSize = (bool)Configer.ConfigHelper.GetValue("IsCheckDiskSize", false);
            allowDiskMinSize = (double)Configer.ConfigHelper.GetValue("AllowDiskMinSize", 1.0);
            autoCreateDateFolder = (bool)Configer.ConfigHelper.GetValue("AutoCreateDateFolder", true);
            isSaveImage = (bool)Configer.ConfigHelper.GetValue("IsSaveImage", true);
            checkNameValidity = (bool)Configer.ConfigHelper.GetValue("CheckNameValidity", false);

            diskName = System.IO.Path.GetPathRoot(saveRootPath);
            GetDiskFreeSpace();
        }

        /// <summary>
        /// 检查根目录是否存在
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns></returns>
        private bool CheckRootPathExit(string rootPath)
        {
            if (rootPath == null)
            {
                Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR, "保存图像路径为空，请设置保存路径.");
                return false;
            }
            else
            {
                if (System.IO.Directory.Exists(rootPath)) return true;
                else
                {
                    //创建文件夹
                    try
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR, $"创建文件夹出错，错误信息：{ex.Message}.");
                        return false;
                    }
                }
            }
        }

        private void SaveImageFunc()
        {
            while (true)
            {
                Thread.Sleep(2);
                if (isSaveImage)
                {
                    if (imageQueue.Count > 0)
                    {
                        SaveImageInfo saveImageInfo = imageQueue.Dequeue();
                        try
                        {
                            if (useCppKernelSave)
                            {
                                var rect = new Rectangle(0, 0, saveImageInfo.image.Width, saveImageInfo.image.Height);
                                var bmpData = saveImageInfo.image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                saveImageInfo.image.PixelFormat);
                                IntPtr psrcImg = bmpData.Scan0;
                                saveImageInfo.image.UnlockBits(bmpData);

                                if (saveImageInfo.image.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                                    SaveGreyImage(psrcImg, saveImageInfo.image.Height, saveImageInfo.image.Width, saveImageInfo.fullName);
                                else if (saveImageInfo.image.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                                    SaveRGB888Image(psrcImg, saveImageInfo.image.Height, saveImageInfo.image.Width, saveImageInfo.fullName);
                                else if (saveImageInfo.image.PixelFormat == System.Drawing.Imaging.PixelFormat.Format4bppIndexed)
                                    Save4bppImage(psrcImg, saveImageInfo.image.Height, saveImageInfo.image.Width, saveImageInfo.fullName);
                                else if (saveImageInfo.image.PixelFormat == System.Drawing.Imaging.PixelFormat.Format16bppRgb565)
                                    SaveRGB565Image(psrcImg, saveImageInfo.image.Height, saveImageInfo.image.Width, saveImageInfo.fullName);
                                else
                                    saveImageInfo.image.Save(saveImageInfo.fullName);
                            }
                            else
                            {
                                saveImageInfo.image.Save(saveImageInfo.fullName);
                            }
                        }
                        catch (Exception ex)
                        {
                            Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR,
                                $"保存图像出错，错误信息{ex.Message}.");
                        }

                    }
                }
            }
        }

        private void GetDiskFreeSpace()
        {
            System.IO.DriveInfo[] dirves = System.IO.DriveInfo.GetDrives();
            foreach (var item in dirves)
            {
                if (item.Name == diskName || item.Name == diskName.ToUpper())
                {
                    diskFreeSpace = item.TotalFreeSpace / Math.Pow(1024, 3);
                    return;
                }
            }
        }


        [DllImport("SaveImageKernel.dll", EntryPoint = "SaveGreyImage", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static bool SaveGreyImage(IntPtr srcImage, int height, int width, string fileName);

        [DllImport("SaveImageKernel.dll", EntryPoint = "SaveRGB888Image", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static bool SaveRGB888Image(IntPtr srrImage, int height, int width, string fileName);

        [DllImport("SaveImageKernel.dll", EntryPoint = "Save4bppImage", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static bool Save4bppImage(IntPtr srrImage, int height, int width, string fileName);
        [DllImport("SaveImageKernel.dll", EntryPoint = "SaveRGB565Image", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static bool SaveRGB565Image(IntPtr srrImage, int height, int width, string fileName);


        #endregion

        #region 委托



        #endregion

        #region 事件

        public event Action<string> SaveRootPathChanged;
        public event Action<bool> SaveImageStateChanged;

        #endregion
    }

    internal class SaveImageInfo
    {
        public Bitmap image = null;
        public string fullName = null;
        public SaveImageInfo(Bitmap img, string _fullName)
        {
            image = img;
            fullName = _fullName;
        }
    }
}
