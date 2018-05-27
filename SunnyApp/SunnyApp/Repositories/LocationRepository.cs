﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SunnyApp.Models;
using SunnyApp.Repositories.Abstractions;

[assembly: Xamarin.Forms.Dependency(typeof(SunnyApp.Services.LocationRepository))]
namespace SunnyApp.Services
{
    public class LocationRepository : IDataStore<Location>, ILocationRepository
    {
        List<Location> items;

        public LocationRepository()
        {
            items = new List<Location>();
            var mockItems = new List<Location>
            {
                new Location { Key = Guid.NewGuid().ToString(), LocalizedName = "First item", },
                new Location { Key = Guid.NewGuid().ToString(), LocalizedName = "Second item", },
                new Location { Key = Guid.NewGuid().ToString(), LocalizedName = "Third item", },
                new Location { Key = Guid.NewGuid().ToString(), LocalizedName = "Fourth item", },
                new Location { Key = Guid.NewGuid().ToString(), LocalizedName = "Fifth item", },
                new Location { Key = Guid.NewGuid().ToString(), LocalizedName = "Sixth item", },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Location item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Location item)
        {
            var _item = items.FirstOrDefault(arg => arg.Key == item.Key);
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string Key)
        {
            var _item = items.FirstOrDefault(arg => arg.Key == Key);
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Location> GetItemAsync(string Key)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Key == Key));
        }

        public async Task<IEnumerable<Location>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public Task<List<Weather>> GetLocationListByTextAsync(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}