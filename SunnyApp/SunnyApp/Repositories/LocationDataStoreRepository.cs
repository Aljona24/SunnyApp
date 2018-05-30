using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunnyApp.Models;
using SunnyApp.Repositories.Abstractions;
using Xamarin.Forms;

namespace SunnyApp.Repositories
{
    class LocationDataStoreRepository : IDataStore<Location>
    {
        private const string KeyPrefix = "location_key_";

        private List<Location> _locationList;

        public LocationDataStoreRepository()
        {
            _locationList = Application.Current.Properties.Where(x => x.Key.Contains($"{KeyPrefix}")).Select(x => (Location)x.Value).ToList();
        }

        public async Task<bool> AddItemAsync(Location location)
        {
            Application.Current.Properties.Add($"{KeyPrefix}{location.Key}", location);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string key)
        {
            Application.Current.Properties.Remove($"{KeyPrefix}{key}");
            await GetItemListAsync();
            return await Task.FromResult(true);
        }

        public async Task<Location> GetItemAsync(string key)
        {
            return await Task.FromResult(_locationList.FirstOrDefault(s => s.Key == key));
        }

        public async Task<IEnumerable<Location>> GetItemListAsync(bool forceRefresh = false)
        {
            _locationList = Application.Current.Properties
                .Where(x => x.Key.Contains($"{KeyPrefix}"))
                .Select(x => (Location)x.Value)
                .ToList();

            return await Task.FromResult(_locationList);
        }
    }
}
