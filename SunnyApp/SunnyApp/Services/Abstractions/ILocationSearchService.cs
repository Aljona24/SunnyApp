using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyApp.Models;

namespace SunnyApp.Services.Abstractions
{
    interface ILocationSearchService
    {
        Task<List<Weather>> GetLocationListByTextAsync(string searchText);
    }
}
