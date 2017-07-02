using System.Collections.Generic;

namespace CDD.Core
{
    public interface Storage
    {
        string[] Load(string name);
        void Save<T>(string name, IEnumerable<T> data);
    }
}
