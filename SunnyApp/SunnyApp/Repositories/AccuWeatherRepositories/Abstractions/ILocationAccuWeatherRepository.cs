using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyApp.Models;

namespace SunnyApp.Repositories.AccuWeatherRepositories.Abstractions
{
    interface ILocationAccuWeatherRepository
    { 
        Task<IList<Location>> GetLocationListByTextAsync(string searchText);
    }
}
