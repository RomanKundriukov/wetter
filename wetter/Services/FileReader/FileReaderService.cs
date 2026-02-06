using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace wetter.Services.FileReader
{
    internal class FileReaderService : IFileReaderService
    {
        private static readonly FileReaderService _instance = new FileReaderService();

        internal static FileReaderService GetInstanse() => _instance!;

        private FileReaderService() { }
        public string GetFilePath() => Path.Combine(AppContext.BaseDirectory, "Jsons", "description.json");

        public async Task<T?> ReadFileAsJsonAsync<T>(string filePath)
        {
            await using var stream = File.OpenRead(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<T>(stream, options);
        }
    }
}
