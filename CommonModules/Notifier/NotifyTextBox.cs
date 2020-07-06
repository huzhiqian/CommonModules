using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonModules.Notifier
{
   public class NotifyTextBox:INotifyBoard
    {
        private TextBox infoTextbox;

        private int showInfoLineCount = 0;

        public NotifyTextBox(TextBox textboxCtrl)
        {
            infoTextbox = textboxCtrl;
            infoTextbox.ScrollBars = ScrollBars.Vertical;
            MaxDisplayCount=50;
            //infoTextbox.AppendText(" \r\n\r\n");
        }

        public int MaxDisplayCount { get; set; } 

        public void CleraBoard()
        {
            ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(infoTextbox,()=> {
                infoTextbox.Text = string.Empty;
            });       
        }

        public void DisplayNitifyItemInfo(NotifyItem info)
        {
            ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(infoTextbox,()=> {
                if (string.IsNullOrEmpty(infoTextbox.Text))
                    showInfoLineCount = 0;
                showInfoLineCount++;
                if (showInfoLineCount > MaxDisplayCount)
                {
                    var line = infoTextbox.Text.Split(new[] { "\r\n\r\n" }, StringSplitOptions.None);
                    infoTextbox.Text = string.Join("\r\n\r\n", line.Skip(1));
                    //infoTextbox.SelectionStart = 0;
                    //int end = infoTextbox.Text.IndexOf("\n\r");//第一行内第一个字符容的索引
                    //int start = infoTextbox.Text.IndexOf("\n\r")-1;//第二行第一个字符的索引
                    //infoTextbox.Select(start, end);//选中第一行
                    //infoTextbox.SelectedText = "";//设置第一行的内容为空
                }
                infoTextbox.AppendText(string.Format("{0} {1}\r\n\r\n", DateTime.Now.ToString("HH:mm:ss.fff"), info.message));
            });
           
        }
    }
}
