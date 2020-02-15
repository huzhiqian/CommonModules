using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Configuration;
using CommonModules.LogHelper;

//**********************************************
//文件名：AppConfigManager
//命名空间：CommonModules.AppConfigManager
//CLR版本：4.0.30319.42000
//内容：
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2019/7/18 20:58:25
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.AppConfigManager
{
   public static class AppConfigManager
    {
        static Configuration _appConfig;
        static bool _error = false;

        #region 构造函数

        static AppConfigManager()
        {
            try
            {
                _appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            catch (ConfigurationErrorsException ex)
            {
                _error = true;
                Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.FATAL,"读取配置文件出错！",ex);
            }
        }

        #endregion


        #region 属性



        #endregion

        #region 公共方法

        public static KeyValueConfigurationCollection AppSettings
        {
            get
            {
                if (_appConfig != null && !_error)
                    return _appConfig.AppSettings.Settings;
                else
                    return null;
            }
        }

        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                if (_appConfig != null && !_error)
                    return _appConfig.ConnectionStrings.ConnectionStrings;
                else
                    return null;
            }

        }


        public static T GetSection<T>(string name) where T : ConfigurationSection
        {
            if (_appConfig == null || _error) return null;
            return _appConfig.GetSection(name) as T;
        }

        #endregion

        #region 私有方法



        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
