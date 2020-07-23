using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using CommonModules.Properties;


//**********************************************
//文件名：NotifyListView
//命名空间：CommonModules.Notifier
//CLR版本：4.0.30319.42000
//内容：
//功能：以ListView为基础的Log通知控件
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/7/23 11:13:49
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.Notifier
{
    public class NotifyListView : INotifyBoard
    {
        private System.Windows.Forms.ListView m_ListView = null;
        private object locker = new object();

        #region 构造函数

        public NotifyListView(System.Windows.Forms.ListView listView)
        {
            m_ListView = listView;
            MaxDisplayCount = 50;
            InitListView();//初始化ListView
        }

        #endregion


        #region 属性

        public int MaxDisplayCount { get; set; }

        #endregion

        #region 公共方法

        /// <summary>
        /// 清空通知项
        /// </summary>
        public void CleraBoard()
        {
            lock (locker)
            {
                ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(m_ListView,
               new Action(() =>
               {
                   m_ListView.Items.Clear();
               }));
            }

        }

        public void DisplayNitifyItemInfo(NotifyItem info)
        {
            lock (locker)
            {
                ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(m_ListView,
                new Action(() =>
                {
                    m_ListView.SuspendLayout();
                    m_ListView.BeginUpdate();
                    ListViewItem item = new ListViewItem();
                    //item.UseItemStyleForSubItems = false;
                    item.Text = DateTime.Now.ToString("HH:mm:ss.fff");
                    switch (info.notifyLevel)
                    {
                        case NotifyLevel.DISPLAY:
                            item.SubItems.Add("DisPlay");
                            item.ImageIndex = 0;
                            break;
                        case NotifyLevel.ALL:
                            item.SubItems.Add("All");
                            item.ImageIndex = 1;
                            break;
                        case NotifyLevel.FATAL:
                            item.SubItems.Add("Fatal");
                            item.ImageIndex = 2;
                            break;
                        case NotifyLevel.ERROR:
                            item.SubItems.Add("Error");
                            item.ImageIndex = 3;
                            break;
                        case NotifyLevel.WARNING:
                            item.SubItems.Add("Warning");
                            item.ImageIndex = 4;
                            break;
                        case NotifyLevel.DEBUG:
                            item.SubItems.Add("Debug");
                            item.ImageIndex = 5;
                            break;
                        case NotifyLevel.INFO:
                            item.SubItems.Add("Info");
                            item.ImageIndex = 6;
                            break;
                        default:
                            break;
                    }
                    item.SubItems.Add(info.message);
                    m_ListView.Items.Add(item);
                    if (m_ListView.Items.Count == 1)
                        AutoResizeColumnWidth(m_ListView);
                    else
                        AutoResizeColumnWidth(m_ListView, item);
                    m_ListView.Items[m_ListView.Items.Count - 1].EnsureVisible();
                    //超出显示范围自动清理
                    if (m_ListView.Items.Count > MaxDisplayCount)
                    {
                        m_ListView.Items.RemoveAt(0);
                    }
                    m_ListView.EndUpdate();
                    m_ListView.ResumeLayout();
                }));
            }
           
        }


        #endregion

        #region 私有方法

        private void InitListView()
        {
            
            //初始化图标
            ImageList imageList = new ImageList();
            imageList.Images.Add((System.Drawing.Image)(Resources.Display));
            imageList.Images.Add((System.Drawing.Image)(Resources.All));
            imageList.Images.Add((System.Drawing.Image)(Resources.Fatal));
            imageList.Images.Add((System.Drawing.Image)(Resources.Error));
            imageList.Images.Add((System.Drawing.Image)(Resources.Warning));
            imageList.Images.Add((System.Drawing.Image)(Resources.Debug));
            imageList.Images.Add((System.Drawing.Image)(Resources.Info));

            ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(m_ListView, new Action(() =>
            {
                m_ListView.View = View.Details;
                m_ListView.Columns.Clear();
                //Add new Columns
                m_ListView.Columns.Add("Time", (m_ListView.Width - 20) / 3, System.Windows.Forms.HorizontalAlignment.Center);
                m_ListView.Columns.Add("Level", (m_ListView.Width - 20) / 3, System.Windows.Forms.HorizontalAlignment.Center);
                m_ListView.Columns.Add("Info", (m_ListView.Width - 50) / 3, System.Windows.Forms.HorizontalAlignment.Left);

                m_ListView.AutoResizeColumns(System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize);//自动适应列头宽度
                m_ListView.SmallImageList = imageList;
            }));
        }

        /// <summary>
        /// 自动适应列宽
        /// </summary>
        /// <param name="lv"></param>
        private void AutoResizeColumnWidth(ListView lv)
        {
            int count = lv.Columns.Count;
            int maxWidth = 0;

            Graphics graphics = lv.CreateGraphics();
            Font font = lv.Font;
            ListView.ListViewItemCollection items = lv.Items;

            string str;
            int width;
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);//先自适应列头宽度
            for (int i = 0; i < count; i++)
            {
                str = lv.Columns[i].Text;
                maxWidth = lv.Columns[i].Width;

                foreach (ListViewItem item in items)
                {
                    str = item.SubItems[i].Text;
                    width = (int)graphics.MeasureString(str, font).Width;
                    if (width > maxWidth)
                    {
                        maxWidth = width;
                    }
                }
                if (i == 0)
                {
                    lv.Columns[i].Width = lv.SmallImageList.ImageSize.Width + maxWidth;
                }
                lv.Columns[i].Width = maxWidth;
            }
        }

        private void AutoResizeColumnWidth(ListView lv, ListViewItem item)
        {
            int maxWidth = 0;
            int width = 0;
            Graphics graphics = lv.CreateGraphics();
            Font font = lv.Font;

            int count = lv.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                string str = lv.Columns[i].Text;
                maxWidth = lv.Columns[i].Width;
                width = (int)graphics.MeasureString(str, font).Width;
                if (i == 0)
                {
                    if (width + lv.SmallImageList.ImageSize.Width > maxWidth)
                    {
                        maxWidth = width;
                        lv.Columns[i].Width = lv.SmallImageList.ImageSize.Width + width;

                    }
                }
                else
                {
                    if (width > maxWidth)
                    {
                        maxWidth = width;
                        lv.Columns[i].Width = width;

                    }
                }
            }
        }
        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
