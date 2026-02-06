using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using wetter.Models.WeatherCode;
using wetter.Services.FileReader;

namespace wetter.Services.WeatherCode
{
    internal class WeatherCodeService
    {
        private static readonly WeatherCodeService? _instanse = new WeatherCodeService(FileReaderService.GetInstanse());

        internal static WeatherCodeService GetInstanse() => _instanse!;

        private IFileReaderService _fileReaderService;

        private WeatherCodeService(IFileReaderService fileReaderService)
        {
            _fileReaderService = fileReaderService;
        }

        public async Task<Dictionary<int, WeatherCodeModel>> GetWeatherCode()
        {
            try
            {
                var filePath = _fileReaderService.GetFilePath();

                var model = await _fileReaderService.ReadFileAsJsonAsync<Dictionary<int, WeatherCodeModel>>(filePath);

                return model ?? throw new InvalidOperationException("JSON konnte nicht gelesen werden oder ist leer.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
