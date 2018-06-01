using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyApp.Models;

namespace SunnyApp.Repositories.AccuWeatherRepositories.Abstractions
{
    public interface IWeatherAccuWeatherRepository
    {
        Task<IList<Weather>> GetWeatherByLocationAsync(string locationKey);
    }
}
