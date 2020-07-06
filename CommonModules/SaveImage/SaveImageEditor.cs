using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonModules.SaveImage
{
    public partial class SaveImageEditor : UserControl
    {
        private SaveImageComponent _subject = null;
        private bool pendingEvent = false;
        public SaveImageEditor()
        {
            InitializeComponent();
        }



        #region 属性

        public SaveImageComponent Subject
        {
            set
            {
                if (value != null)
                {
                    pendingEvent = true;
                    _subject = value;
                    SetSubject();
                    pendingEvent = false;
                }
            }
        }

        #endregion

        #region 私有方法

        private void SetSubject()
        {
            //
            tbx_SaveImagePath.Text = _subject.SaveRootPath;
            chk_autoCreateDateFolder.Checked = _subject.AutoCreateDateFolder;
            chk_checkNameValidity.Checked = _subject.CheckNameValidity;
            chk_imageNameEndWithTime.Checked = _subject.ImageNameEndWithTime;
            chk_isCheckDiskSize.Checked = _subject.IsCheckDiskSize;
            num_DiskSize.Enabled = _subject.IsCheckDiskSize;
            num_DiskSize.Value = Convert.ToDecimal( _subject.AllowDiskMinSize);
            switch (_subject.SaveType)
            {
                case SaveImageType.PNG:
                    rb_png.Checked = true;
                    break;
                case SaveImageType.BMP:
                    rb_bmp.Checked = true;
                    break;
                case SaveImageType.JPG:
                    rb_jpg.Checked = true;
                    break;
                default:
                    rb_bmp.Checked = true;
                    break;
            }
            chk_IsSaveImage.Checked = _subject.IsSaveImage;
            _subject.SaveImageStateChanged -= SaveImageStateChanged;
            _subject.SaveImageStateChanged += SaveImageStateChanged;
            //
            _subject.SaveRootPathChanged -= SaveRootPathChanged;
            _subject.SaveRootPathChanged += SaveRootPathChanged;
        }

        private void SaveImageStateChanged(bool state)
        {
            if (chk_IsSaveImage.InvokeRequired)
            {
                chk_IsSaveImage.Invoke(new Action(() =>
                {
                    chk_IsSaveImage.Checked = state;
                }));
            }
            else
            {
                chk_IsSaveImage.Checked = state;
            }

        }

        private void SaveRootPathChanged(string path)
        {
            if (tbx_SaveImagePath.InvokeRequired)
            {
                tbx_SaveImagePath.Invoke(new Action(() =>
                {
                    tbx_SaveImagePath.Text = path;
                }));
            }
            else
                tbx_SaveImagePath.Text = path;
        }



        #endregion

        private void btn_Bowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "选择保存图像路径";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _subject.SaveRootPath = folderBrowserDialog.SelectedPath;
            }
        }

        private void chk_imageNameEndWithTime_CheckedChanged(object sender, EventArgs e)
        {
            if (!pendingEvent)
            {
                if (_subject != null)
                {
                    _subject.ImageNameEndWithTime = chk_imageNameEndWithTime.Checked;
                }
            }
        }

        private void chk_checkNameValidity_CheckedChanged(object sender, EventArgs e)
        {
            if (!pendingEvent)
            {
                if (_subject != null)
                {
                    _subject.CheckNameValidity = chk_checkNameValidity.Checked;
                }
            }
        }

        private void chk_autoCreateDateFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (!pendingEvent)
            {
                if (_subject != null)
                {
                    _subject.AutoCreateDateFolder = chk_autoCreateDateFolder.Checked;
                }
            }
        }

        private void chk_isCheckDiskSize_CheckedChanged(object sender, EventArgs e)
        {
            if (!pendingEvent)
            {
                if (_subject != null)
                {
                    _subject.IsCheckDiskSize = chk_isCheckDiskSize.Checked;
                    num_DiskSize.Enabled = chk_isCheckDiskSize.Checked;
                }
            }
        }

        private void chk_IsSaveImage_CheckedChanged(object sender, EventArgs e)
        {
            if (!pendingEvent)
            {
                if (_subject != null)
                {
                    _subject.IsSaveImage = chk_IsSaveImage.Checked;
                }
            }
        }

        private void num_DiskSize_ValueChanged(object sender, EventArgs e)
        {
            if (!pendingEvent)
            {
                if (_subject != null)
                {
                    _subject.AllowDiskMinSize = Convert.ToDouble(num_DiskSize.Value);
                }
            }
        }

        private void rb_bmp_CheckedChanged(object sender, EventArgs e)
        {
            if (!pendingEvent) {
                if (_subject != null)
                {
                    _subject.SaveType = SaveImageType.BMP;
                }
            }
        }

        private void rb_jpg_CheckedChanged(object sender, EventArgs e)
        {
            if (!pendingEvent)
            {
                if (_subject != null)
                {
                    _subject.SaveType = SaveImageType.JPG;
                }
            }
        }

        private void rb_png_CheckedChanged(object sender, EventArgs e)
        {
            if (!pendingEvent)
            {
                if (_subject != null)
                {
                    _subject.SaveType = SaveImageType.PNG;
                }
            }
        }
    }
}
