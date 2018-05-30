using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunnyApp.ApiRequestHelper;
using SunnyApp.Models;
using SunnyApp.Repositories.Abstractions;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(SunnyApp.Repositories.LocationRepository))]
namespace SunnyApp.Repositories
{
    public class LocationRepository : IDataStore<Location>, ILocationRepository
    {
        private const string KeyPrefix = "location_key_";

        List <Location> LocationList;

        public LocationRepository()
        {
            LocationList = new List<Location>();
            LocationList = Application.Current.Properties.Where(x => x.Key.Contains($"{KeyPrefix}")).Select(x => (Location)x.Value).ToList();
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
            return await Task.FromResult(LocationList.FirstOrDefault(s => s.Key == key));
        }

        public async Task<IEnumerable<Location>> GetItemListAsync(bool forceRefresh = false)
        {
            LocationList = Application.Current.Properties.Where(x => x.Key.Contains($"{KeyPrefix}")).Select(x => (Location)x.Value).ToList();
            return await Task.FromResult(LocationList);
        }

        public Task<IList<Location>> GetLocationListByTextAsync(string searchText)
        {
            return RequestBuilder.BuildGetRequest("http://dataservice.accuweather.com")
                .SetPathPart($"locations/v1/search")
                .AddQueryStringParameter("apikey", "JN3fCDgzMkUOpEqZU0yAXKAEezj1p2Ew") //JN3fCDgzMkUOpEqZU0yAXKAEezj1p2Ew   wJxBCJ6VUaN4TFVRTKzmn3RGuWx0FbWb
                .AddQueryStringParameter("q", $"{searchText}")
                .GetAsync<IList<Location>>();
        }
    }
}