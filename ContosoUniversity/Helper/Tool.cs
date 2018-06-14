using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Tool
    {
        public Tool()
        {

        }
        public static Tool getHelper() {
            return new Tool();
        }

        public T DeserializeJsonToObject<T>(string json) where T : class {
            T t = null;
            try {
                JsonSerializer serializer = new JsonSerializer();
                StringReader sr = new StringReader(json);
                object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
                t = o as T;
            }
            catch (Exception) {
                t = null;

            }

            return t;
        }
        /// <summary>
        /// 将对象序列化为JSON格式
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>json字符串</returns>
        public string SerializeObject(object o) {
            string json = JsonConvert.SerializeObject(o);
            return json;
        }
        /// <summary>
        /// 解析JSON数组生成对象实体集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <returns>对象实体集合</returns>
        public List<T> DeserializeJsonToList<T>(string json) where T : class {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = o as List<T>;
            return list;
        }
    }
}
