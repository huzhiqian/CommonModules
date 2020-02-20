using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;


//**********************************************
//文件名：ConfigHelper
//命名空间：CommonModules.Configer
//CLR版本：4.0.30319.42000
//内容：读取配置项数据和写入配置项数据
//功能：配置文件操作类
//文件关系：ConfigHelper依赖ConfigItemManager
//作者：胡志乾
//小组：
//生成日期：2020/2/15 20:14:16
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.Configer
{
    public class ConfigHelper
    {
        private static ConfigItemManager _configItemManager=null; //配置项管理对象
        #region 构造函数

        public ConfigHelper()
        {

        }

        #endregion


        #region 属性


        private static ConfigItemManager MyConfigItemManager
        {
            get {
                if (_configItemManager == null)
                {
                    CustomConfigurationBaseSection section = 
                        AppConfigManager.AppConfigManager.GetSection<CustomConfigurationBaseSection>("Configer");
                    if (section != null)
                    {
                        string fullName = System.Environment.CurrentDirectory + @"\" + section.ConfigFileName;
                        _configItemManager = ConfigItemManager.CreateInstance(fullName);
                    }
                    else
                    {
                        _configItemManager = ConfigItemManager.CreateInstance();
                    }
                }
                return _configItemManager;
            }
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取配置项值
        /// </summary>
        /// <param name="key">配置项键值</param>
        /// <returns></returns>
        public static object GetValue(string key)
        {
            return MyConfigItemManager[key];
        }

        /// <summary>
        /// 获取配置项键值
        /// </summary>
        /// <param name="key">配置项键值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static object GetValue(string key,object defaultValue)
        {
            if (MyConfigItemManager.ContainsKey(key))
            {
                return MyConfigItemManager[key];
            }
            else
            {

                return defaultValue;
            }
        }

        /// <summary>
        /// 保存配置项值
        /// </summary>
        /// <param name="key">配置项</param>
        /// <param name="value">配置项值</param>
        public static void SaveValue(string key,object value)
        {
            try
            {
                MyConfigItemManager.AddConfigItem(new ConfigItem(key,value));
                _configItemManager.SerializeSave();
            }
            catch (Exception ex)
            {
                Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR,$"保存配置项：{key} 出错",ex);
            }
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
