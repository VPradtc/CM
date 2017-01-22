using System;

namespace CardMatch.Serialization.Core
{
    public interface ISerializer<T>
        where T : new()
    {
        void Serialize(T target, string filePath);
        T Deserialize(string filePath);
    }
}
