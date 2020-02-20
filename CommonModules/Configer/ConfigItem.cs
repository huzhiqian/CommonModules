using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;


//**********************************************
//文件名：ConfigItem
//命名空间：CommonModules.Configer
//CLR版本：4.0.30319.42000
//内容：key,value,description
//功能：描述配置文件中每一个节点中的内容
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/2/3 16:53:27
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.Configer
{
   public class ConfigItem
    {
        private string _key = string.Empty;
        private object _value = null;
        private string _description = "";
        #region 构造函数

        public ConfigItem()
        {

        }

        public ConfigItem(string key,object value,string descript="")
        {
            _key = key;
            _value = value;
            _description = descript;
        }
        #endregion


        #region 属性
        /// <summary>
        /// 获取配置项Key
        /// </summary>
        public string Key {
            get { return _key; }
            set { _key = value; }
        }

        /// <summary>
        /// 获取或设置配置项值
        /// </summary>
        public object Value {
            get { return _value; }
            set {
                _value = value;

            }
        }

        /// <summary>
        /// 获取或设置配置项描述值
        /// </summary>
        public string Description {
            get { return _description; }
            set { _description = value; }
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
