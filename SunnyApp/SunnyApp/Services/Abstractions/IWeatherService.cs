using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyApp.Models;

namespace SunnyApp.Services.Abstractions
{
    public interface IWeatherService
    {
        Task<IList<Weather>> GetWeatherByLocationAsync(string locationKey);
    }
}