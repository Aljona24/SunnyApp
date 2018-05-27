using System.Threading.Tasks;
using SunnyApp.Models;

namespace SunnyApp.Services.Abstractions
{
    public interface IWeatherService
    {
        Task<Weather> GetWeatherByLocationAsync(string locationKey);

    }
}