using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
//**********************************************
//文件名：NotifyRichTextBox
//命名空间：CommonModules.Notifier
//CLR版本：4.0.30319.42000
//内容：
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/5/18 23:19:52
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.Notifier
{
    public class NotifyRichTextBox : INotifyBoard
    {
        private RichTextBox richTextBox;
        private int showInfoLineCount = 0;
        public NotifyRichTextBox(RichTextBox _richTextBox )
        {
            richTextBox = _richTextBox;
        
            MaxDisplayCount = 50;
        }
        public int MaxDisplayCount { get ; set ; }

        public void CleraBoard()
        {
            ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(richTextBox, () => {
                richTextBox.Text = string.Empty;
            });
        }

        private List<NotifyItem> infoList = new List<NotifyItem>();
        public void DisplayNitifyItemInfo(NotifyItem info)
        {
            ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(richTextBox, () => {
                if (string.IsNullOrEmpty(richTextBox.Text))
                    showInfoLineCount = 0;
                richTextBox.SuspendLayout();
                string str = string.Format("{0} {1}\r\n\r\n", DateTime.Now.ToString("HH:mm:ss.fff"), info.message);
                info.message = str;
                infoList.Add(info);
               
                richTextBox.Clear();
                foreach (var item in infoList)
                {
                    switch (item.notifyLevel)
                    {
                        case NotifyLevel.DISPLAY:
                            richTextBox.SelectionColor = Color.Black;
                            break;
                        case NotifyLevel.ALL:
                            richTextBox.SelectionColor = Color.Blue;
                            break;
                        case NotifyLevel.FATAL:
                            richTextBox.SelectionColor = Color.DarkRed;
                            break;
                        case NotifyLevel.ERROR:
                            richTextBox.SelectionColor = Color.Red;
                            break;
                        case NotifyLevel.WARNING:
                            richTextBox.SelectionColor = Color.DeepPink;
                            break;
                        case NotifyLevel.DEBUG:
                            richTextBox.SelectionColor = Color.Green;
                            break;
                        case NotifyLevel.INFO:
                            richTextBox.SelectionColor = Color.Orange;
                            break;
                        default:
                            break;

                    }
                
                    richTextBox.AppendText(item.message);
                }
               
                if (showInfoLineCount > MaxDisplayCount)
                {
                    infoList.RemoveAt(0);
                    //richTextBox.SelectionStart = 0;
                    //richTextBox1.SelectionLength = richTextBox1.GetFirstCharIndexFromLine(1);
                    //richTextBox.SelectionLength =richTextBox.Text.IndexOf("\n\n")+1;
                    //richTextBox.SelectedText="";
                }
                else
                    showInfoLineCount++;
                richTextBox.ResumeLayout();
                //richTextBox.Focus();
                richTextBox.Select(richTextBox.TextLength, 0);
                richTextBox.ScrollToCaret();
                //richTextBox.Refresh();
            });
        }
    }
}
