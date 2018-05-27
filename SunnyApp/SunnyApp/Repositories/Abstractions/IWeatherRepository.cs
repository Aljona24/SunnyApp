using System.Threading.Tasks;
using SunnyApp.Models;

namespace SunnyApp.Repositories.Abstractions
{
    public interface IWeatherRepository
    {
        Task<Weather> GetWeatherByLocationAsync(string locationKey);
    }
}
