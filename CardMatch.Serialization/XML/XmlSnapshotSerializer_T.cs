using CardMatch.Serialization.Core;
using System.IO;
using System.Xml.Serialization;

namespace CardMatch.Serialization.XML
{
    public class XmlSnapshotSerializer<T> : ISerializer<T>
        where T : new()
    {
        public void Serialize(T target, string filePath)
        {
            TextWriter writer = null;

            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = File.CreateText(filePath);
                serializer.Serialize(writer, target);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public T Deserialize(string filePath)
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);

                var result = (T)serializer.Deserialize(reader);
                return result;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}

