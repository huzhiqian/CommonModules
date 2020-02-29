using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using System.IO;
using System.Data;

//**********************************************
//文件名：XmlHelper
//命名空间：CommonModules.XML
//CLR版本：4.0.30319.42000
//内容：
//功能：读取xml文件中的数据
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/2/27 20:39:41
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.XML
{
    public class XmlHelper
    {
        /// <summary>
        /// xml文件物理路径
        /// </summary>
        private string _filePath = string.Empty;
        private XmlDocument _xmlDoc; //xml文档对象
        private XmlElement _rootElement;//xml的根节点

        #region 构造函数

        /// <summary>
        /// 实例化XmlHelper对象
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public XmlHelper(string xmlFilePath)
        {
            try
            {
                _filePath = System.IO.Path.GetFullPath(xmlFilePath);
                CreateXMLRootElement();
            }
            catch (Exception ex)
            {
                Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR,
                    $"打开XML文件 {xmlFilePath} 失败!", ex);
                throw ex;
            }

        }

        #endregion


        #region 属性



        #endregion

        #region 公共方法

        /// <summary>
        /// 获取指定XPath表达式节点对象
        /// </summary>
        /// <param name="xPath">xPath表达式</param>
        /// 范例1：@"Skill/First/SkillItem"，等效于@"//Skill/First/SkillItem"
        /// 范例2：@"Table[USERNAME='a']",[]表示筛选，USERNAME是Table下的一个子节点
        /// 
        /// <returns></returns>
        public XmlNode GetNode(string xPath)
        {
            return _rootElement.SelectSingleNode(xPath);
        }


        /// <summary>
        /// 获取指定xPath表达式节点的值
        /// </summary>
        /// 范例：@"Skill/First/SkillItem",等效于 @"//Skill/First/SkillItem"
        /// 范例：@"Table[USERNAME='a']",[]表示筛选，USERNAME是Table下的一个子节点
        /// 范例：@"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性
        /// <param name="xPath">xPath表达式</param>
        /// <returns></returns>
        public string GetValue(string xPath)
        {
            return _rootElement.SelectSingleNode(xPath).InnerText;
        }



        /// <summary>
        /// 获取指定xPath节点表达式的属性值
        /// </summary>
        /// <param name="xPath">xPath节点表达式</param>
        /// <param name="attributeName">属性名</param>
        /// 范例：@"Skill/First/SkillItem",等效于 @"//Skill/First/SkillItem"
        /// 范例：@"Table[USERNAME='a']",[]表示筛选，USERNAME是Table下的一个子节点
        /// 范例：@"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性
        /// <returns></returns>
        public string GetAttributeValue(string xPath, string attributeName)
        {
            return _rootElement.SelectSingleNode(xPath).Attributes[attributeName].Value;
        }

        /// <summary>
        /// 新增节点
        /// 将任意节点插入到当前xml文件中
        /// </summary>
        /// <param name="xmlNode">要插入的xml节点对象</param>
        public void AppendNode(XmlNode xmlNode)
        {
            XmlNode node = _xmlDoc.ImportNode(xmlNode, true);//true：表示深度克隆，如果为false则仅导入节点，而不复制数据或子节点
        }

        /// <summary>
        /// 新增节点
        /// 将dataset中的第一天记录插入到xml文件中
        /// </summary>
        /// <param name="ds">DataSet的实例，该DataSet中应该只有一条记录</param>
        public void AppendNode(DataSet ds)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(ds.GetXml());
            XmlNode node = xmlDocument.DocumentElement.FirstChild;
            AppendNode(node);
        }


        /// <summary>
        /// 删除指定xPath表达式的节点
        /// </summary>
        ///  范例：@"Skill/First/SkillItem",等效于 @"//Skill/First/SkillItem"
        ///  范例：@"Table[USERNAME='a']",[]表示筛选，USERNAME是Table下的一个子节点
        ///  范例：@"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性
        /// <param name="xPath">xPath表达式</param>
        public void DeleteNode(string xPath)
        {
            XmlNode node = _xmlDoc.SelectSingleNode(xPath);
            _rootElement.RemoveChild(node);
        }

        /// <summary>
        /// 保存XML文件
        /// </summary>
        public void Save()
        {
            _xmlDoc.Save(this._filePath);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 创建xml根节点
        /// </summary>
        private void CreateXMLRootElement()
        {
            if (_xmlDoc == null)
            {
                _xmlDoc = new XmlDocument();
                if (System.IO.File.Exists(_filePath))
                    _xmlDoc.Load(this._filePath);
                else
                {
                    CommonModules.Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR,
                        $"未能找到XML文件 {_filePath}");
                    throw new DirectoryNotFoundException(_filePath);
                }
            }
            if (_rootElement == null)
                _rootElement = _xmlDoc.DocumentElement;
        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 创建根节点对象
        /// </summary>
        /// <param name="xmlFilePath">xml文件路径</param>
        /// <returns></returns>
        private static XmlElement CreateRootElement(string xmlFilePath)
        {
            string filePath = string.Empty;
            filePath = System.IO.Path.GetFullPath(xmlFilePath);
            XmlDocument _xmlDocument = new XmlDocument();
            _xmlDocument.Load(filePath);
            return _xmlDocument.DocumentElement;
        }


        /// <summary>
        /// 获取指定xPath节点表达式值
        /// </summary>
        /// <param name="xmlFilePath">xml文件路径</param>
        /// <param name="xPath">xPath节点表达式</param>
        /// <returns></returns>
        /// 范例：@"Skill/First/SkillItem",等效于 @"//Skill/First/SkillItem"
        /// 范例：@"Table[USERNAME='a']",[]表示筛选，USERNAME是Table下的一个子节点
        /// 范例：@"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性

        public static string GetValue(string xmlFilePath, string xPath)
        {
            XmlElement xmlRootElement = CreateRootElement(xmlFilePath);

            return xmlRootElement.SelectSingleNode(xPath).InnerText;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <param name="xPath"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public static string GetAttributeValue(string xmlFilePath,string xPath,string attributeName)
        {
            //创建根对象
            XmlElement xmlRootElement = CreateRootElement(xmlFilePath);
            //返回xPath节点属性值
            return xmlRootElement.SelectSingleNode(xPath).Attributes[attributeName].Value;
        }

        #endregion
    }
}
