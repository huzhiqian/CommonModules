using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;


//**********************************************
//文件名：AbstractSaveImage
//命名空间：CommonModules.SaveImage
//CLR版本：4.0.30319.42000
//内容：
//功能：保存图片的抽象类
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/6/19 10:50:45
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.SaveImage
{
    public interface ISaveImage
    {

        #region 属性

        string SaveRootPath { get; set; }

        SaveImageType SaveType { get; set; }

        bool ImageNameEndWithTime { get; set; }

        bool IsCheckDiskSize { get; set; }

        double AllowDiskMinSize { get; set; }

        bool AutoCreateDateFolder { get; set; }

        bool IsSaveImage { get; set; }

        bool CheckNameValidity { get; set; }
        #endregion

        /// <summary>
        /// 通过保存文件的全名保存图像
        /// </summary>
        /// <param name="image">图像对象</param>
        /// <param name="imagefullName">图像的名称的全名(绝对路径)</param>
        void SaveImageByFullName(Bitmap image, string imagefullName);


        /// <summary>
        /// 保存图像
        /// </summary>
        /// <param name="image">图像对象</param>
        /// <param name="imgName">图形名称</param>
        void SaveImage(Bitmap image, string imgName);

        #region 时间

        event Action<string> SaveRootPathChanged;

        event Action<bool> SaveImageStateChanged;

        #endregion

    }
}
