using log4net;


//**********************************************
//文件名：LogHelper
//命名空间：CommonModules.LogHelper
//CLR版本：4.0.30319.42000
//内容：包含ErrorLogger，FatalLogger，InfoLogger等
//功能：记录log
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2019/6/30 20:18:45
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.LogHelper
{
    public static class LogHelper
    {
        private static ILog logger_Fatal = log4net.LogManager.GetLogger("Logger_Fatal");
        private static ILog logger_Error = log4net.LogManager.GetLogger("Logger_Error");
        private static ILog logger_Warning = log4net.LogManager.GetLogger("Logger_Warn");
        private static ILog logger_Debug = log4net.LogManager.GetLogger("Logger_Debug");
        private static ILog logger_Info = log4net.LogManager.GetLogger("Logger_Info");


        #region 公共方法

        public static void WriteLog(LogLevel level, string logInfo)
        {
            switch (level)
            {
                case LogLevel.ALL:
                    AllLog(logInfo);
                    break;
                case LogLevel.FATAL:
                    FatalLog(logInfo);
                    break;
                case LogLevel.ERROR:
                    ErrorLog(logInfo);
                    break;
                case LogLevel.WARNING:
                    WarningLog(logInfo);
                    break;
                case LogLevel.DEBUG:
                    DebugLog(logInfo);
                    break;
                case LogLevel.INFO:
                    InfoLog(logInfo);
                    break;
                default:
                    break;
            }
        }


        public static void WriteLog(LogLevel level, string logInfo, System.Exception ex)
        {
            switch (level)
            {
                case LogLevel.ALL:
                    AllLog(logInfo,ex);
                    break;
                case LogLevel.FATAL:
                    FatalLog(logInfo, ex);
                    break;
                case LogLevel.ERROR:
                    ErrorLog(logInfo, ex);
                    break;
                case LogLevel.WARNING:
                    WarningLog(logInfo, ex);
                    break;
                case LogLevel.DEBUG:
                    DebugLog(logInfo, ex);
                    break;
                case LogLevel.INFO:
                    InfoLog(logInfo, ex);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 私有方法

        //Fatal
        private static void FatalLog(string logInfo)
        {
            logger_Fatal.Fatal(logInfo);
        }

        private static void FatalLog(string logInfo, System.Exception ex)
        {
            logger_Fatal.Fatal(logInfo, ex);
        }

        //Error
        private static void ErrorLog(string logInfo)
        {
            logger_Error.Error(logInfo);
        }

        private static void ErrorLog(string logInfo, System.Exception ex)
        {
            logger_Error.Error(logInfo, ex);
        }

        //Warning
        private static void WarningLog(string logInfo)
        {
            logger_Warning.Warn(logInfo);
        }
        private static void WarningLog(string logInfo, System.Exception ex)
        {
            logger_Warning.Warn(logInfo,ex);
        }

        //Debug
        private static void DebugLog(string logInfo)
        {
            logger_Debug.Debug(logInfo);
        }

        private static void DebugLog(string logInfo, System.Exception ex)
        {
            logger_Debug.Debug(logInfo, ex);
        }

        //Info
        private static void InfoLog(string logInfo)
        {
            logger_Info.Info(logInfo);
        }

        private static void InfoLog(string logInfo, System.Exception ex)
        {
            logger_Info.Info(logInfo,ex);
        }

        //All
        private static void AllLog(string logInfo)
        {
            FatalLog(logInfo);
            ErrorLog(logInfo);
            WarningLog(logInfo);
            DebugLog(logInfo);
            InfoLog(logInfo);
        }

        private static void AllLog(string logInfo,System.Exception ex)
        {
            FatalLog(logInfo,ex);
            ErrorLog(logInfo,ex);
            WarningLog(logInfo,ex);
            DebugLog(logInfo,ex);
            InfoLog(logInfo,ex);
        }
        #endregion

    }

    public enum LogLevel
    {
        ALL = 0,
        FATAL = 1,
        ERROR = 2,
        WARNING = 3,
        DEBUG = 4,
        INFO = 5
    }
}
