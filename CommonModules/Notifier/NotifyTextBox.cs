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
        }

        public int MaxDisplayCount { get; set; } 

        public void CleraBoard()
        {
            infoTextbox.Text = string.Empty;
        }

        public void DisplayNitifyItemInfo(NotifyItem info)
        {
            if (string.IsNullOrEmpty(infoTextbox.Text))
                showInfoLineCount = 0;
            showInfoLineCount++;
            if (showInfoLineCount > MaxDisplayCount)
            {
                var line = infoTextbox.Text.Split(new[] { "\r\n"},StringSplitOptions.None);
                infoTextbox.Text = string.Join(System.Environment.NewLine,line.Skip(1));
            }
            infoTextbox.AppendText ( string.Format("{0} {1}\r\n",DateTime.Now.ToString("HH:mm:ss.fff"),info.message));
        }
    }
}
