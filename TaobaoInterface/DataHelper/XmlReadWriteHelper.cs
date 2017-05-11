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
        /// ��xmlfile�����ڣ������쳣 
        /// </exception>
        public XmlReadWriteHelper(string xmlFile)
        {
            if(!File.Exists(xmlFile))
            {
                throw new FileNotFoundException(string.Format("xml file������{0}",xmlFile));
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
        /// �ϲ�
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
        /// ����Ƕ����Ŀ��xml����
        /// </summary>
        /// <param name="asm">Ƕ����Ŀ����</param>
        /// <param name="path">�ļ�����Ŀ�е�·��</param>
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
        /// ȡĳ����ֵ
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
                throw new XmlException(string.Format("���{0}������", nodePath));
            }
        }
        public string GetSubNodeValue(XmlNode node,string subNodePath)
        {
            XmlNode subNode = node.SelectSingleNode(subNodePath);
            if (subNode != null)
                return subNode.InnerText;
            else
            {
                throw new XmlException(string.Format("�ӽ��{0}������", subNodePath));
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
        /// �����ֵ
        /// </summary>
        /// <param name="nodePath">�Ӹ���㿪ʼ</param>
        public void SetNodeValue(string nodePath,string value)
        {
            XmlNode node = GetNode(nodePath);
            node.InnerText = value;

        }

        /// <summary>
        /// ��ӽ���ֵ
        /// </summary>
        /// <param name="nodePath">�Ӹ���㿪ʼ</param>
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
        /// ���¼���xml����
        /// </summary>
        public void Reload()
        {
            doc_.Load(xmlFile_);
        }
       
        /// <summary>
        /// ���浵��
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
                throw new XmlException(string.Format("{0}����{1}������", node.Name, attributeName));
        }

        public void SetNodeAttribute(string nodePath, string attributeName,string value)
        {
            XmlNode node=GetNode(nodePath);
            node.Attributes[attributeName].Value = value;
            
        }
        /// <summary>
        /// ���л�����
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="t">����</param>
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
        /// �����л�Ϊ����
        /// </summary>
        /// <param name="type">��������</param>
        /// <param name="s">�������л����Xml�ַ���</param>
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
        /// ���л� �����ַ���
        /// </summary>
        /// <param name="obj">���Ͷ���</param>
        /// <returns>���л�����ַ���</returns>
        public static string SerializeToString<T>(T obj)
        {
            if (obj != null)
            {
                XmlSerializer xs = new XmlSerializer(obj.GetType());

                MemoryStream stream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
                writer.Formatting = Formatting.None;//����
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