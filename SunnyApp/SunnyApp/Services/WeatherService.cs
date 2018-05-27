using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyApp.Models;
using SunnyApp.Repositories.Abstractions;

namespace SunnyApp.Services
{
    class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<Weather> GetWeatherByLocationAsync(string locationKey)
        {
            return await _weatherRepository.GetWeatherByLocationAsync(locationKey);
        }
    }
}
