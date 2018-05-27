using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyApp.Models;

namespace SunnyApp.Repositories.Abstractions
{
    public interface IWeatherRepository
    {
        Task<IList<Weather>> GetWeatherByLocationAsync(string locationKey);
    }
}
