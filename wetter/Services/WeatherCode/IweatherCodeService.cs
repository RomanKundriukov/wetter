using System.Collections.Generic;
using System.Threading.Tasks;
using wetter.Models.WeatherCode;

namespace wetter.Services.WeatherCode
{
    internal interface IWeatherCodeService
    {
        Task<Dictionary<int, WeatherCodeModel>> GetWeatherCode();
    }
}
