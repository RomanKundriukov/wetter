using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace wetter.Services.FileReader
{
    /// <summary>
    /// Provides file reading and JSON deserialization services for internal application use.
    /// </summary>
    /// <remarks>This class offers methods to retrieve the path to a specific JSON file and to asynchronously
    /// read and deserialize JSON content from files. It is implemented as a singleton to ensure a single, shared
    /// instance within the application. The FileReaderService is intended for internal use and is not designed for
    /// direct access by external consumers.</remarks>
    internal class FileReaderService : IFileReaderService
    {
        /// <summary>
        /// Provides a singleton instance of the FileReaderService class.
        /// </summary>
        /// <remarks>This instance is intended for internal use to ensure a single, shared
        /// FileReaderService throughout the application. Access to this instance should be managed through appropriate
        /// public members if external usage is required.</remarks>
        private static readonly FileReaderService _instance = new FileReaderService();

        /// <summary>
        /// Retrieves the singleton instance of the FileReaderService.
        /// </summary>
        /// <remarks>This method provides access to the application's sole FileReaderService instance. The
        /// returned instance is guaranteed to be initialized. This method is intended for internal use only.</remarks>
        /// <returns>The single, shared instance of the FileReaderService.</returns>
        internal static FileReaderService GetInstanse() => _instance!;

        private FileReaderService() { }

        /// <summary>
        /// Gets the full file path to the "description.json" file located in the "Jsons" directory under the
        /// application's base directory.
        /// </summary>
        /// <returns>A string containing the absolute path to the "description.json" file.</returns>
        public string GetFilePath() => Path.Combine(AppContext.BaseDirectory, "Jsons", "description.json");

        /// <summary>
        /// Asynchronously reads the contents of a file and deserializes it as JSON into an object of type T.
        /// </summary>
        /// <remarks>The deserialization is case-insensitive with respect to property names. Ensure that
        /// the file exists and contains valid JSON to avoid exceptions.</remarks>
        /// <typeparam name="T">The type to which the JSON content is deserialized.</typeparam>
        /// <param name="filePath">The path to the file to read. The file must contain valid JSON representing an object of type T.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized object of type
        /// T, or null if the file is empty.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while reading the file or deserializing the JSON content.</exception>
        public async Task<T?> ReadFileAsJsonAsync<T>(string filePath)
        {
            try
            {
                await using var stream = File.OpenRead(filePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                return await JsonSerializer.DeserializeAsync<T>(stream, options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
