using System.Collections.Generic;
using System.IO;
using System.Linq;
using CDD.Core;

namespace CDD.ConsoleApp
{
    public class FileStorage : Storage
    {
        private const string Extension = ".prg";

        public string[] Load(string name)
            => File.ReadAllLines(name + Extension);

        public void Save<T>(string name, IEnumerable<T> data)
            => File.WriteAllLines(name + Extension, data.Select(v => v.ToString()));
    }
}
