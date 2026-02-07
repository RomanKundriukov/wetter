using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wetter.Models.ListModels
{
    internal class SmallWeatherModel
    {
        internal TimeOnly Zeit {  get; set; }
        internal TimeOnly Aufgang { get; set; }
        internal TimeOnly Untergang { get; set; }
        internal string WeatherCodeImagePath { get; set; } = string.Empty;
        internal double WeatherTemperatur { get; set; }
    }
}
