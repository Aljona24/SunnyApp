using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyApp.Models;
using SunnyApp.Services.Abstractions;

namespace SunnyApp.Services
{
    class LocationSearchService : ILocationSearchService
    {
        public Task<List<Weather>> GetLocationListByTextAsync(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
