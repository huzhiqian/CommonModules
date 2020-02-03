using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Json;


//**********************************************
//文件名：SerializerHelper
//命名空间：CommonModules.SerializerHelper
//CLR版本：4.0.30319.42000
//内容：提供二进制序列化、XML序列化和Json序列化三个类
//功能：序列化和反序列化
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/2/3 9:30:20
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.SerializerHelper
{

    /// <summary>
    /// 功能：序列化反序列化二进制文件，要求被序列化的对像是有[Serializable]属性标记的。
    /// </summary>
    public class BinarySerialization
    {

        #region 公共方法

        /// <summary>
        /// 将文件序列化成文件并保存
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">序列化对象</param>
        /// <param name="filePath">保存路径</param>
        /// <returns></returns>
        public static bool SerializeFile<T>(T obj, string filePath)
        {
            return SerializeBinaryFile(obj, filePath);
        }


        /// <summary>
        /// 将文件反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static T DeserializeFile<T>(string filePath)
        {
            return DeserializeBinaryFile<T>(filePath);
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 二进制反序列化器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        private static T DeserializeBinaryFile<T>(string path)
        {
            T obj = default(T);
            FileStream fs = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Exists)
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.Read,FileShare.Read);
                    obj = (T)formatter.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (fs != null)
                    ((IDisposable)fs).Dispose();
            }
            return obj;
        }

        /// <summary>
        /// 二进制序列化器
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool SerializeBinaryFile(object obj, string path)
        {
            bool result = false;
            FileStream fs = null;
            try
            {
                if (obj != null)
                {
                    //创建文件流
                    fs = new FileStream(path, FileMode.Create);
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, obj);
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (fs != null)
                    ((IDisposable)fs).Dispose();
            }
            return result;
        }
        #endregion


    }

    /// <summary>
    /// 功能：序列化反序列化XML文件
    /// </summary>
    public class XMLSerialization
    {

        #region 公共方法

        /// <summary>
        /// 将对象序列化成字符串
        /// </summary>
        /// <param name="o">序列化对象</param>
        /// <returns></returns>
        public static string Serialize(object o)
        {
            return XMLSerialize(o);
        }

        /// <summary>
        /// 将字符串反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="str">反序列化的字符串</param>
        /// <returns></returns>
        public static T Deserialize<T>(string str)
        {
            return XmlDeserialize<T>(str);
        }

        /// <summary>
        /// 将对象序列化成文件并保存
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">序列化对象</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static bool SerializeFile<T>(T obj, string filePath)
        {
            return SerializeXMLFile(obj, filePath);
        }

        /// <summary>
        /// 将文件反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static T DeserializeFile<T>(string path)
        {
            return DeserializeXMLFile<T>(path);
        }
        #endregion


        #region 私有方法

        /// <summary>
        /// 将对象序列化成XML字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string XMLSerialize(object obj)
        {
            XmlSerializer xmlSeri = new XmlSerializer(obj.GetType(),
                new Type[] { typeof(int[]), typeof(double[]), typeof(string[]), typeof(float[]) });

            System.IO.MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, Encoding.UTF8);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSeri.Serialize(writer, obj, ns);
            writer.Close();
            return Encoding.UTF8.GetString(ms.ToArray());
        }


        private static T XmlDeserialize<T>(string str)
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.LoadXml(str);
                XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlDocument.DocumentElement);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(xmlNodeReader);
            }
            catch (Exception ex)
            {
                //return default(T);
                throw ex;
            }
        }

        /// <summary>
        /// XML序列化器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        private static bool SerializeXMLFile(object obj, string Path)
        {
            bool result = false;
            FileStream fs = null;
            try
            {
                if (obj != null)
                {
                    //创建文件流
                    fs = new FileStream(Path, FileMode.Create);

                    XmlSerializer serializer = new XmlSerializer(obj.GetType(),
                        new Type[] { typeof(int[]), typeof(double[]), typeof(float[]), typeof(string[]) });

                    serializer.Serialize(fs, obj);
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (fs != null)
                    ((IDisposable)fs).Dispose();
            }
            return result;
        }


        /// <summary>
        /// xml反序列化器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        private static T DeserializeXMLFile<T>(string path)
        {
            T obj = default(T);
            FileStream fs = null;
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                XmlSerializer serializer = new XmlSerializer(typeof(T),
                  new Type[] { typeof(int[]), typeof(double[]), typeof(float[]), typeof(string[]) }// ,
                                                                                                   //typeof(List<int>), typeof(List<double>), typeof(List<float>), typeof(List<string>) }
                  );

                if (fileInfo.Exists)
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    obj= (T)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                if (fs != null)
                    ((IDisposable)fs).Dispose();
            }
            return obj;
        }
        #endregion
    }


    /// <summary>
    /// 功能：序列化反序列化文件（以Json方式）
    /// </summary>
    public class  JsonSerialization
    {

        #region 公共方法

        /// <summary>
        /// 将对象根据格式（XML/JSON）序列化成字符串结果
        /// </summary>
        /// <param name="obj">需要序列化的对象</param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            return JsonSerailize(obj);
        }


        /// <summary>
        /// 将制定字符串反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="str">反序列化字符串</param>
        /// <returns></returns>
        public static T Deserialize<T>(string str)
        {
            return JsonDeserialize<T>(str);
        }

        /// <summary>
        /// 将对象序列化成Json文件并保存
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">序列化对象</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static bool SerializeJson<T>(T obj,string filePath)
        {
            return SerializerJsonFile(obj,filePath);
        }

        /// <summary>
        /// 将Json文件反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static T DeserializeJson<T>(string filePath)
        {
            return DeserializeJsonFile<T>(filePath);
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 将对象序列化成Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string JsonSerailize(object obj)
        {
            using (var ms = new MemoryStream())
            {
                new DataContractJsonSerializer(obj.GetType()).WriteObject(ms,obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        /// <summary>
        /// Json字符串反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="str">反序列化字符串</param>
        /// <returns></returns>
        private static T JsonDeserialize<T>(string str)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
            }
        }



        private static bool SerializerJsonFile(object obj,string path)
        {
            bool result = false;
            try
            {
                string strJson = JsonSerailize(obj);
                StreamWriter sw = System.IO.File.CreateText(path);
                sw.WriteLine();
                sw.Close();
                result = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        private static T DeserializeJsonFile<T>(string path)
        {
            T obj = default(T);
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Exists)
                {
                    StreamReader sr = new StreamReader(path,Encoding.UTF8);
                    string line = string.Empty;
                    StringBuilder sb = new StringBuilder();
                    while ((line = sr.ReadLine()) != null)
                    {
                        sb.Append(line);
                    }
                    obj = JsonDeserialize<T>(sb.ToString());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }
        #endregion
    }
}
