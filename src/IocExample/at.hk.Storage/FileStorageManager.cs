using System;
using System.IO;
using System.Xml.Serialization;

namespace at.hk.Storage
{
    public class FileStorageManager : IStorageManager 
    {
        #region Implementation of IStorageManager

        public bool Save<T>(string name, T data)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }

            if (!Path.HasExtension(name))
            {
                name += ".txt";
            }

            string outputPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\StorageHandlerOutputFiles\");
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            using (Stream stream = new FileStream(outputPath + name, FileMode.Append))
            {
                if (TrySerialize(stream, data))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        private bool TrySerialize<TMyType>(Stream stream, TMyType data)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TMyType));
                serializer.Serialize(stream, data);
                stream.Flush();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
