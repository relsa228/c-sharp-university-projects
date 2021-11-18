using System.Collections.Generic;

namespace LR_10.FileServiceLib
{
    interface IFileService<T> where T:class
    {
        IEnumerable<T> ReadFile(string fileName);
        void SaveData(IEnumerable<T> data, string fileName);
    }
}