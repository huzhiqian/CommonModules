using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModules.Notifier
{
   public class NotifyItem
    {
        public NotifyLevel notifyLevel = NotifyLevel.DISPLAY;
        public string message = string.Empty;
        public NotifyItem(string msg)
        {
            message = msg;
        }

        public NotifyItem( NotifyLevel level, string msg)
        {
             notifyLevel=level;
            message = msg;
        }

        public NotifyItem(NotifyItem othre)
        {
            notifyLevel = othre.notifyLevel;
            message = othre.message;
        }

    }

    public enum NotifyLevel
    {
        DISPLAY=-1, //只显示
        ALL=0,      //记录到所有的Logger中
        FATAL=1,
        ERROR=2,
        WARNING=3,
        DEBUG=4,
        INFO=5
    }
}
