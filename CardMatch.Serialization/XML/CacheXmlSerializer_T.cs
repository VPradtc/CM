using CardMatch.Serialization.Core;

namespace CardMatch.Serialization.XML
{
    public class CacheXmlSerializer<T> : ISerializer<T>
        where T: new()
    {
        private XmlSnapshotSerializer<T> _coreSerializer;

        private T _lastSavedVersion;

        public CacheXmlSerializer(XmlSnapshotSerializer<T> coreSerializer)
        {
            _coreSerializer = coreSerializer;
        }

        public void Serialize(T target, string filePath)
        {
            _coreSerializer.Serialize(target, filePath);
            _lastSavedVersion = target;
        }

        public T Deserialize(string filePath)
        {
            if (_lastSavedVersion != null)
            {
                return _lastSavedVersion;
            }

            return _coreSerializer.Deserialize(filePath);
        }
    }
}
