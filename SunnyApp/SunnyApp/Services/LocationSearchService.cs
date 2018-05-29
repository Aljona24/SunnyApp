using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyApp.Models;
using SunnyApp.Repositories.Abstractions;
using SunnyApp.Services.Abstractions;

namespace SunnyApp.Services
{
    class LocationSearchService : ILocationSearchService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationSearchService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IList<Location>> GetLocationListByTextAsync(string searchText)
        {
            return await _locationRepository.GetLocationListByTextAsync(searchText);
        }
    }
}
