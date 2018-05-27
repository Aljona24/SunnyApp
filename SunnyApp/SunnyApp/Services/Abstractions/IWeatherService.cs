using System.Threading.Tasks;
using SunnyApp.Models;

namespace SunnyApp.Services
{
    public interface IWeatherService
    {
        Task<Weather> GetWeatherByLocationAsync(string locationKey);

    }
}