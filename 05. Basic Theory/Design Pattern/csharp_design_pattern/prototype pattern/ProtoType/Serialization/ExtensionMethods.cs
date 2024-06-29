using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var dataContractSerializer = new DataContractSerializer(typeof(T));
            using var memoryStream = new MemoryStream();
            dataContractSerializer.WriteObject(memoryStream, self);
            memoryStream.Position = 0;
            return (T)dataContractSerializer.ReadObject(memoryStream)!;

            // BinaryFormatter는 사용되지 않는다. 이제는.. 보안 이슈..
            //MemoryStream stream = new MemoryStream();
            //BinaryFormatter formatter = new BinaryFormatter();
            //formatter.Serialize(stream, self);
            //stream.Seek(0, SeekOrigin.Begin);
            //object copy = formatter.Deserialize(stream);
            //stream.Close();
            //return (T)copy;
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms)!;
            }
        }
    }
}
