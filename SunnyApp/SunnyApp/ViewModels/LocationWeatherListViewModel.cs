using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SunnyApp.Models;
using SunnyApp.Services.Abstractions;
using SunnyApp.Views;

namespace SunnyApp.ViewModels
{
    public class LocationWeatherListViewModel : BaseViewModel
    {
        private readonly ILocationSearchService _locationSearchServiceService;
        private readonly IWeatherService _weatherService;
        public ObservableCollection<LocationWeather> LocationWeatherList { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ICommand RemoveItemCommand { get; set; }


        public LocationWeatherListViewModel(IWeatherService weatherService, ILocationSearchService locationSearchServiceService)
        {
            _weatherService = weatherService;
            _locationSearchServiceService = locationSearchServiceService;
            Title = "Browse Weather";
            LocationWeatherList = new ObservableCollection<LocationWeather>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadLocationListFromDataStoreCommandAsync());

            RemoveItemCommand = new Command<string>(async (key) => await ExecuteRemoveItemFromDataStoreCommandAsync(key));

            MessagingCenter.Subscribe<SearchLocationListPage, Location>(this, "AddItem", async (obj, location) =>
            {
                var weatherList = await _weatherService.GetCurrentWeatherByLocationAsync(location.Key);
                var locationWeather = new LocationWeather
                {
                    Location = location,
                    CurrentWeather = weatherList.FirstOrDefault()
                };

                LocationWeatherList.Add(locationWeather);
                await _locationSearchServiceService.AddItemAsync(location);
            });
        }

        async Task ExecuteRemoveItemFromDataStoreCommandAsync(string key)
        {
            await ExecuteCommandAsync(async () =>
            {
                await _locationSearchServiceService.DeleteItemAsync(key);
                LocationWeatherList.Clear();
                var locationList = await _locationSearchServiceService.GetItemListAsync(true);

                foreach (var location in locationList)
                {
                    var weatherList = await _weatherService.GetCurrentWeatherByLocationAsync(location.Key);
                    var locationWeather = new LocationWeather
                    {
                        Location = location,
                        CurrentWeather = weatherList.FirstOrDefault()
                    };

                    LocationWeatherList.Add(locationWeather);
                }
            });
        }

        async Task ExecuteLoadLocationListFromDataStoreCommandAsync()
        {
            await ExecuteCommandAsync(async () =>
            {
                LocationWeatherList.Clear();
                var locationList = await _locationSearchServiceService.GetItemListAsync(true);
                foreach (var location in locationList)
                {
                    var weatherList = await _weatherService.GetCurrentWeatherByLocationAsync(location.Key);
                    var locationWeather = new LocationWeather
                    {
                        Location = location,
                        CurrentWeather = weatherList.FirstOrDefault()
                    };

                    LocationWeatherList.Add(locationWeather);
                }
            });
        }
    }
}