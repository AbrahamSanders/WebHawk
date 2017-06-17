using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace UBoat.Utils
{
    public static class Converter
    {
        public static byte[] ToBinary(object Obj)
        {
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, Obj);
                bytes = ms.ToArray();
            }
            return bytes;
        }

        public static T FromBinary<T>(byte[] Bytes)
        {
            T obj;
            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                BinaryFormatter bf = new BinaryFormatter();
                obj = (T)bf.Deserialize(ms);
            }
            return obj;
        }

        public static string ToJSON(object Obj)
        {
            return JsonConvert.SerializeObject(Obj);
        }

        public static T FromJSON<T>(string JSON)
        {
            return JsonConvert.DeserializeObject<T>(JSON);
        }
    }
}
