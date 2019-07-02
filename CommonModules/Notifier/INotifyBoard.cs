using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonModules.Notifier
{
   public interface INotifyBoard
    {
        int MaxDisplayCount { get; set; }

        void DisplayNitifyItemInfo(NotifyItem info);
        void CleraBoard();
    }
}
