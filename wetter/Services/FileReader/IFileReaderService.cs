using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wetter.Services.FileReader
{
    /// <summary>
    /// Defines methods for retrieving a file path and reading the contents of a file as a JSON string asynchronously.
    /// </summary>
    internal interface IFileReaderService
    {
        string GetFilePath();

        Task<T?> ReadFileAsJsonAsync<T>(string filePath);
    }
}
