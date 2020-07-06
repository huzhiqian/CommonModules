using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonModules.Notifier
{
   public static class NotifyHelper
    {

         static INotifyBoard notifyBoard;
        static bool isSetNitifyBoard = false;


        public static INotifyBoard NotifyBoard
        {
            get { return notifyBoard; }
            set {
                notifyBoard = value;
                isSetNitifyBoard = true;
            }
        }

        public static void Notify(NotifyLevel level, string info)
        {
            if (isSetNitifyBoard)
                ShowInfo( level,info);
            WriteInfoToLog(level,info);
        }


        public static void Notify(NotifyLevel level, string info,params object[] args)
        {
            string msg = string.Format(info, args);
            if (isSetNitifyBoard)
                ShowInfo(level,  msg);
            WriteInfoToLog(level, msg);
        }


        public static void Notify(NotifyLevel level, string info,Exception ex)
        {
            string msg = string.Format("{0}_{1}",info,ex.Message);
            if (isSetNitifyBoard)
                ShowInfo(level, msg);

            WriteInfoToLog(level, info,ex);
        }

        public static void Notify(NotifyLevel level, string info, Exception ex, params object[] args)
        {
            string msg = string.Format("{0}_{1}", info, ex.Message);
            msg = string.Format(msg,args);
            if (isSetNitifyBoard)
                ShowInfo(level, msg);

            WriteInfoToLog(level, msg, ex);
        }

        #region 私有方法



        private static void WriteInfoToLog(NotifyLevel level, string msg)
        {
            switch (level)
            {
                case NotifyLevel.DISPLAY:
                    break;
                case NotifyLevel.ALL:
                    LogHelper.LogHelper.WriteLog(LogHelper.LogLevel.ALL, msg);
                    break;
                case NotifyLevel.FATAL:
                    LogHelper.LogHelper.WriteLog(LogHelper.LogLevel.FATAL, msg);
                    break;
                case NotifyLevel.ERROR:
                    LogHelper.LogHelper.WriteLog(LogHelper.LogLevel.ERROR, msg);
                    break;
                case NotifyLevel.WARNING:
                    LogHelper.LogHelper.WriteLog(LogHelper.LogLevel.WARNING, msg);
                    break;
                case NotifyLevel.DEBUG:
                    LogHelper.LogHelper.WriteLog(LogHelper.LogLevel.DEBUG, msg);
                    break;
                case NotifyLevel.INFO:
                    LogHelper.LogHelper.WriteLog(LogHelper.LogLevel.INFO, msg);
                    break;
                default:
                    break;
            }
        }

        private static void WriteInfoToLog(NotifyLevel level, string msg, System.Exception ex)
        {
            switch (level)
            {
                case NotifyLevel.DISPLAY:
                    break;
                case NotifyLevel.ALL:
                    LogHelper.LogHelper.WriteLog(LogHelper.LogLevel.ALL, msg, ex);
                    break;
                case NotifyLevel.FATAL:
                    LogHelper.LogHelper.WriteLog(LogHelper.LogLevel.FATAL, msg, ex);
                    break;
                case NotifyLevel.ERROR:
                    LogHelper.LogHelper.WriteLog(LogHelper.LogLevel.ERROR, msg, ex);
                    break;
                case NotifyLevel.WARNING:
                    LogHelper.LogHelper.WriteLog(LogHelper.LogLevel.WARNING, msg, ex);
                    break;
                case NotifyLevel.DEBUG:
                    LogHelper.LogHelper.WriteLog(LogHelper.LogLevel.DEBUG, msg, ex);
                    break;
                case NotifyLevel.INFO:
                    LogHelper.LogHelper.WriteLog(LogHelper.LogLevel.INFO, msg, ex);
                    break;
                default:
                    break;
            }
        }


        private static void ShowInfo(NotifyLevel level,string msg)
        {
            NotifyItem notifyItem = new NotifyItem(level, msg);
            notifyBoard.DisplayNitifyItemInfo(notifyItem);
        }

        #endregion

    }
}
