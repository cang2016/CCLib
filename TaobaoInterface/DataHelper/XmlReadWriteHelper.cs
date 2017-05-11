using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    public class XmlReadWriteHelper
    {
        private XmlDocument doc_ = null;
        private string xmlFile_=string.Empty;

        private XmlElement xmlRoot_;

        public XmlElement XmlRoot
        {
            get { return doc_.DocumentElement; }
            set { xmlRoot_ = value; }
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <exception cref="FileNotFoundException">
        /// 若xmlfile不存在，引发异常 
        /// </exception>
        public XmlReadWriteHelper(string xmlFile)
        {
            if(!File.Exists(xmlFile))
            {
                throw new FileNotFoundException(string.Format("xml file不存在{0}",xmlFile));
            }
            xmlFile_ = xmlFile;
            doc_ = new XmlDocument();
            doc_.Load(xmlFile);
            
        }
        public XmlReadWriteHelper(Stream stream)
        {
            doc_ = new XmlDocument();
            doc_.Load(stream);
            
        }
        /// <summary>
        /// 合并
        /// </summary>
        /// <param name="file"></param>
        public void Merge(string file)
        {
            XmlDocument doc = new XmlDocument();
            
            doc.Load(file);
            XmlNode root = doc_.ImportNode(doc.DocumentElement, true);
            doc_.DocumentElement.AppendChild(root);
            
        }

        public XmlReadWriteHelper()
        {
            doc_ = new XmlDocument();
        }   
        public void Load(string xmlFile)
        {
            doc_.Load(xmlFile);
        }
        public void Load(Stream stream)
        {
            doc_.Load(stream);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlSnippet"></param>
        /// <returns></returns>
        public static XmlReadWriteHelper Create(string xmlSnippet)
        {            
            MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(xmlSnippet));
            return new XmlReadWriteHelper(stream);
            
        }

        public static XmlReadWriteHelper Create(string xmlSnippet,Encoding encode)
        {
            MemoryStream stream = new MemoryStream(encode.GetBytes(xmlSnippet));
            return new XmlReadWriteHelper(stream);

        }

    

        /// <summary>
        /// 根据嵌入项目的xml创建
        /// </summary>
        /// <param name="asm">嵌入项目程序集</param>
        /// <param name="path">文件在项目中的路径</param>
        /// <returns></returns>
        public static XmlReadWriteHelper Create(Assembly asm, string path)
        {
            Stream strm = asm.GetManifestResourceStream(path);
            if (strm == null)
            {
                throw new Exception(string.Format("Can't find file!,check the asm'{0}' and path'{1}'."
                                                  ,asm.FullName,path));
            }
            
            return new XmlReadWriteHelper(strm);
        }

        /// <summary>
        /// 取某结点的值
        /// </summary>
        /// <param name="nodePath"></param>
        /// <returns></returns>
        public XmlNode GetNode(string nodePath)
        {
            XmlNode node= doc_.SelectSingleNode(nodePath);
            if (node != null)
                return node;
            else
            {
                throw new XmlException(string.Format("结点{0}不存在", nodePath));
            }
        }
        public string GetSubNodeValue(XmlNode node,string subNodePath)
        {
            XmlNode subNode = node.SelectSingleNode(subNodePath);
            if (subNode != null)
                return subNode.InnerText;
            else
            {
                throw new XmlException(string.Format("子结点{0}不存在", subNodePath));
            }
        }

        public string GetNodeValue(string nodePath)
        {
            XmlNode node = GetNode(nodePath);
            if (node == null)
                return "";
            else
                return node.InnerText.Trim();
        }

        public static string GetNodeValue(XmlNode xmlNode,string nodePath)
        {
            XmlNode node = xmlNode.SelectSingleNode(nodePath);
            if (node == null)
                return "";
            else
                return node.InnerText.Trim();
        }

        /// <summary>
        /// 设结点的值
        /// </summary>
        /// <param name="nodePath">从根结点开始</param>
        public void SetNodeValue(string nodePath,string value)
        {
            XmlNode node = GetNode(nodePath);
            node.InnerText = value;

        }

        /// <summary>
        /// 添加结点的值
        /// </summary>
        /// <param name="nodePath">从根结点开始</param>
        public XmlNode AddNode(XmlNode parentNode, string nodeName, string value)
        {
            //XmlNode parentNode = GetNode(nodePath);
            XmlElement elem = doc_.CreateElement(nodeName);
            elem.InnerText = value;
            return parentNode.AppendChild(elem);
        }

        public void AddNodeAttribute(XmlNode node , string attributeName, string value)
        {
            XmlAttribute att = doc_.CreateAttribute(attributeName);
            att.InnerText = value;
            node.Attributes.Append(att);
            //node.Attributes[attributeName].Value = value;
        }


        public string GetNodeAttributeValue(string nodePath,string attributeName)
        {
            XmlNode node = GetNode(nodePath);
            return GetNodeAttributeValue(node, attributeName);           
        }
    

        /// <summary>
        /// 重新加载xml档案
        /// </summary>
        public void Reload()
        {
            doc_.Load(xmlFile_);
        }
       
        /// <summary>
        /// 保存档案
        /// </summary>
        public void Save()
        {
            
            doc_.Save(xmlFile_);
        }



        public XmlNodeList GetNodes(string nodePath)
        {
            return doc_.SelectNodes(nodePath);
        }

        public string GetNodeAttributeValue(XmlNode node, string attributeName)
        {
            if (node.Attributes[attributeName] != null)
                return node.Attributes[attributeName].Value;
            else
                throw new XmlException(string.Format("{0}属性{1}不存在", node.Name, attributeName));
        }

        public void SetNodeAttribute(string nodePath, string attributeName,string value)
        {
            XmlNode node=GetNode(nodePath);
            node.Attributes[attributeName].Value = value;
            
        }
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">对象</param>
        /// <returns></returns>
        public static string Serialize<T>(T t)
        {
            XmlSerializer xs = new XmlSerializer(t.GetType());
            MemoryStream stream = new MemoryStream();
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Encoding = new UTF8Encoding(false);
            setting.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(stream, setting))
            {
                xs.Serialize(writer, t);
            }
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        /// <summary>
        /// 反序列化为对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="s">对象序列化后的Xml字符串</param>
        /// <returns></returns>
        public static object StringDeserialize(Type type, string s)
        {
            using (StringReader sr = new StringReader(s))
            {
                XmlSerializer xz = new XmlSerializer(type);
                return xz.Deserialize(sr);
            }
        }
        /// <summary>
        /// 序列化 对象到字符串
        /// </summary>
        /// <param name="obj">泛型对象</param>
        /// <returns>序列化后的字符串</returns>
        public static string SerializeToString<T>(T obj)
        {
            if (obj != null)
            {
                XmlSerializer xs = new XmlSerializer(obj.GetType());

                MemoryStream stream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
                writer.Formatting = Formatting.None;//缩进
                xs.Serialize(writer, obj);

                stream.Position = 0;
                StringBuilder sb = new StringBuilder();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                
                sb.Append(reader.ReadToEnd());
                reader.Close();
                writer.Close();
                return sb.ToString();
            }
            return string.Empty;
        }
        public void SaveAs(string fileName)
        {
            doc_.Save(fileName);
        }
        public static object Deserialize(Type t, string filepath)
        {
            if (!File.Exists(filepath))
                return null;

            XmlSerializer ser = new XmlSerializer(t);

            using (FileStream fs = File.OpenRead(filepath))
            {
                return ser.Deserialize(fs);
            }
        }
        public static object Deserialize<T>(List<string> files) 
        {
            List<T> list = new List<T>();
            foreach (string path in files)
            {
                if (!File.Exists(path))
                    continue;

                XmlSerializer ser = new XmlSerializer(typeof(List<T>));

                using (FileStream fs = File.OpenRead(path))
                {
                    list.AddRange(ser.Deserialize(fs) as List<T>);
                }
            }
            return list;
        }
        public static void Serialize<T>(T t, string filepath)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xz = new XmlSerializer(t.GetType());
                FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
                xz.Serialize(fs, t);

            }
        }
    }
}