using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyApp.Models;

namespace SunnyApp.Repositories.Abstractions
{
    interface ILocationRepository
    { 
        Task<List<Weather>> GetLocationListByTextAsync(string searchText);
    }
}
