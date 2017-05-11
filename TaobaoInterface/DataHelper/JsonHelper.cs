using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Common
{
    public class JsonHelper
    {
        public static string ObjToJson(object obj)
        {
            string jsonText =  Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            return jsonText;
        }

        #region Json序列化
        /// <summary>
        /// JsonSerializer序列化
        /// </summary>
        /// <param name="item">对象</param>
        public static string ToJson<T>(T item)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, item);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        ///// <summary>
        ///// JsonSerializer反序列化
        ///// </summary>
        ///// <param name="str">字符串序列</param>
        public static T FromJson<T>(string str) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                return serializer.ReadObject(ms) as T;
            }
        }

        ///// <summary>
        ///// JsonSerializer反序列化
        ///// </summary>
        ///// <param name="str">字符串序列</param>
        public static T FromJson<T>(dynamic obj) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            if (obj != null && (obj as object) != null)
            {
                string str = (obj as object).ToString();
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
                {
                    return serializer.ReadObject(ms) as T;
                }
            }

            return null;
        }

        ///// <summary>
        ///// JsonSerializer反序列化
        ///// </summary>
        ///// <param name="str">字符串序列</param>
        public static T FromJson<T>(T obj) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

            string str = obj.ToString();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                return serializer.ReadObject(ms) as T;
            }
        }

        #endregion
    }
}
