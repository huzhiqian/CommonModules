using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;


//**********************************************
//文件名：CustomConfigurationBaseSection
//命名空间：CommonModules.Configer
//CLR版本：4.0.30319.42000
//内容：包含一些常用基本配置项，自定义配置节中包含[ConfigFileName]:配置文件名；[ID]:id；[Value]:值这三项基础配置项
//功能：配置文件自定义配置项基类
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2019/7/18 20:41:17
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.Configer
{
   public class CustomConfigurationBaseSection:ConfigurationSection
    {

        #region 构造函数

        public CustomConfigurationBaseSection()
        {
            this.ConfigFileName = "Config.cfg";
            this.ID = 1;
            this.Value = string.Empty;
        }

        public CustomConfigurationBaseSection(string cfgFile, int id, string value)
        {
            this.ConfigFileName = cfgFile;
            this.ID = id;
            this.Value = value;
        }

        #endregion


        #region 属性

        /// <summary>
        /// 配置文件名称，默认名为Config.cfg,且是必须的。不可包含[~!@#$%^&*()[]{}/;'\"|\\]这些非法字符。
        /// 文件名最小长度为3，最大长度为50
        /// </summary>
        [ConfigurationProperty("ConfigFile", DefaultValue = "Config.cfg", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\"/*非法字符*/, MaxLength = 50, MinLength = 3)]
        public string ConfigFileName
        {
            get { return (string)this["ConfigFile"]; }
            set
            {
                this["ConfigFile"] = value;
            }
        }

        [ConfigurationProperty("ID", DefaultValue = 1, IsRequired = false)]
        [IntegerValidator(MaxValue = 999, MinValue = 1)]
        public int ID
        {
            get { return (int)this["ID"]; }
            set { this["ID"] = value; }
        }

        [ConfigurationProperty("Value", DefaultValue = null, IsRequired = false)]
        //[StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\"/*非法字符*/, MaxLength = 50, MinLength = 1)]
        public string Value
        {
            get { return (string)this["Value"]; }
            set { this["Value"] = value; }
        }

        #endregion

        #region 公共方法



        #endregion

        #region 私有方法



        #endregion

        #region 委托



        #endregion

        #region 事件



        #endregion
    }
}
