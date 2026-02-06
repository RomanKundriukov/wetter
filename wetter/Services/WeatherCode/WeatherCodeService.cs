using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using wetter.Models.WeatherCode;
using wetter.Services.FileReader;

namespace wetter.Services.WeatherCode
{
    /// <summary>
    /// Provides access to weather code data loaded from a file source.
    /// </summary>
    /// <remarks>This service is intended for internal use and manages the retrieval of weather code
    /// information from a file using an injected file reader service. The class is implemented as a singleton and is
    /// not thread-safe for write operations beyond its intended usage pattern.</remarks>
    internal class WeatherCodeService : IWeatherCodeService
    {

        private static readonly WeatherCodeService? _instanse = new WeatherCodeService(FileReaderService.GetInstanse());

        internal static WeatherCodeService GetInstanse() => _instanse!;

        private static readonly object locker = new object();

        private IFileReaderService _fileReaderService;

        private WeatherCodeService(IFileReaderService fileReaderService)
        {
            _fileReaderService = fileReaderService;
        }

        public async Task<Dictionary<int, WeatherCodeModel>> GetWeatherCode()
        {
            bool acquiredLock = false;
            try
            {
                Monitor.Enter(locker, ref acquiredLock);

                var filePath = _fileReaderService.GetFilePath();

                var model = await _fileReaderService.ReadFileAsJsonAsync<Dictionary<int, WeatherCodeModel>>(filePath);

                return model ?? throw new InvalidOperationException("JSON konnte nicht gelesen werden oder ist leer.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (acquiredLock) Monitor.Exit(locker);
            }
        }
    }
}
