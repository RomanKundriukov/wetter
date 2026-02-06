using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wetter.Models.WeatherCode;

namespace wetter.Services.WeatherCode
{
    internal interface IWeatherCodeService
    {
        Task<Dictionary<int, WeatherCodeModel>> GetWeatherCode();
    }
}
