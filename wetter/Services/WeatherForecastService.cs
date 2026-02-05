using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wetter.Services
{
    internal class WeatherForecastService
    {
        /// <summary>
        /// Represents the singleton instance of the WeatherForecastService.
        /// </summary>
        private static readonly WeatherForecastService? _instance = new WeatherForecastService();
        /// <summary>
        /// Initializes a new instance of the WeatherForecastService class.
        /// </summary>
        /// <remarks>This constructor is private and is intended to restrict instantiation of the
        /// WeatherForecastService class to within the class itself. Use provided factory methods or static members to
        /// obtain an instance, if available.</remarks>
        private WeatherForecastService() { }
        /// <summary>
        /// Gets the singleton instance of the WeatherForecastService.
        /// </summary>
        /// <remarks>Use this method to access the WeatherForecastService throughout the application. The
        /// same instance is returned on each call.</remarks>
        /// <returns>The single, shared instance of the WeatherForecastService.</returns>
        public static WeatherForecastService GetInstance() => _instance!;
    }
}
