using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;


//**********************************************
//文件名：ConfigItemManager
//命名空间：CommonModules.Configer
//CLR版本：4.0.30319.42000
//内容：自定义配置文件管理对象
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/2/3 9:24:00
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.Configer
{
    public sealed class ConfigItemManager   //该类不可被继承
    {
        private string fullPath = string.Empty;
        private Dictionary<string, ConfigItem> configs =
            new Dictionary<string, ConfigItem>();//存储所有配置项的字典

        private static object syncLock = new object();//同步锁
        private static ConfigItemManager _configItemManager;
        #region 构造函数

        private ConfigItemManager()
        {

        }


        private ConfigItemManager(string filePath)
        {
            try
            {
                LoadConfigsFromXMLFile(filePath);
            }
            catch (Exception ex)
            {
                Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.FATAL, "读取配置文件出错！", ex);
                throw ex;
            }
        }

        public static ConfigItemManager CreateInstance()
        {
            if (_configItemManager == null)
            {
                lock (syncLock)//双重锁定
                {
                    if (_configItemManager == null)
                    {
                        _configItemManager = new ConfigItemManager();
                    }
                }
            }
            return _configItemManager;
        }

        public static ConfigItemManager CreateInstance(string filePath)
        {
            if (_configItemManager == null)
            {
                lock (syncLock)//双重锁定
                {
                    if (_configItemManager == null)
                    {
                        _configItemManager = new ConfigItemManager(filePath);
                    }
                }
            }
            return _configItemManager;
        }
        #endregion


        #region 属性

        /// <summary>
        /// 通过索引值获取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                if (ContainsKey(key))
                {
                    return configs[key].Value;
                }
                else
                {
                    return null;
                }
            }
        }


        public object GetConfigItem(string key, object defaultValue)
        {
            if (this.ContainsKey(key))
            {
                return this[key];
            }
            else
            {
                SaveConfigItem(key, defaultValue);
                return defaultValue;
            }
        }


        public void SaveConfigItem(string key, object value)
        {
            try
            {
                AddConfigItem(new ConfigItem(key, value));
                SerializeSave(this.fullPath);
            }
            catch (Exception ex)
            {

                Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR, $"保存配置项:{key}出错！", ex);
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 从XML文件中读取配置数据
        /// </summary>
        /// <param name="path"></param>
        public void LoadConfigsFromXMLFile(string path)
        {
            lock (syncLock)
            {
                this.fullPath = path;
                if (!System.IO.File.Exists(path))
                {
                    AddConfigItem(new ConfigItem("Sample_Key", "Sample_Value", "NULL"));
                    //序列化保存
                    SerializeSave(this.fullPath);
                    return;
                }

                try
                {
                    List<ConfigItem> items = SerializerHelper.XMLSerialization.DeserializeFile
                        <List<ConfigItem>>(path);
                    configs = items.ToDictionary(key => key.Key, value => value);
                }
                catch (Exception ex)
                {
                    Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR, "加载配置文件出错！", ex);
                    throw ex;
                }
            }
        
        }

        /// <summary>
        /// 向配置项字典中添加配置项
        /// </summary>
        /// <param name="cfgItem"></param>
        public void AddConfigItem(ConfigItem cfgItem)
        {
            lock (syncLock)
            {
                if (configs.ContainsKey(cfgItem.Key))
                {
                    configs.Remove(cfgItem.Key);
                }
                configs.Add(cfgItem.Key, cfgItem);
            }
        }

        public void SerializeSave()
        {
            SerializeSave(this.fullPath);
        }

        public void SerializeSave(string path)
        {
            lock (syncLock)
            {
                List<ConfigItem> valueList = configs.Values.ToList();
                try
                {
                    SerializerHelper.XMLSerialization.SerializeFile(valueList, path);
                }
                catch (Exception ex)
                {
                    Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR, "配置项序列化保存出错！", ex);
                    throw ex;
                }
            }
         
        }

        /// <summary>
        /// 返回配置项中是否包含指定Key项
        /// </summary>
        /// <param name="key">配置项key</param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return configs.ContainsKey(key);
        }
        #endregion

        #region 私有方法

        private ConfigItem GetItem(string key)
        {
            lock (syncLock)
            {
                if (configs.ContainsKey(key))
                {
                    return configs[key];
                }
                else
                {
                    Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR, $"未找到配置项：{key}！");
                    return null;
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
