using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using SunnyApp.Models;
using SunnyApp.Services.Abstractions;
using SunnyApp.Views;

namespace SunnyApp.ViewModels
{
    public class LocationListViewModel : BaseViewModel
    {
        private readonly IWeatherService _weatherService;

        public ObservableCollection<LocationWeather> LocationWeatherList { get; set; }
        public Command LoadItemsCommand { get; set; }

        public LocationListViewModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
            Title = "Browse";
            LocationWeatherList = new ObservableCollection<LocationWeather>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadLocationListFromDataStoreCommandAsync());

            MessagingCenter.Subscribe<NewLocationPage, Location>(this, "AddItem", async (obj, location) =>
            {
                var weatherList = await _weatherService.GetWeatherByLocationAsync(location.Key);
                var locationWeather = new LocationWeather
                {
                    Location = location,
                    CurrentWeather = weatherList.FirstOrDefault()
                };

                LocationWeatherList.Add(locationWeather);
                await DataStore.AddItemAsync(location);
            });
        }

        async Task ExecuteLoadLocationListFromDataStoreCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                LocationWeatherList.Clear();
                var locationList = await DataStore.GetItemsAsync(true);
                foreach (var location in locationList)
                {
                    var weatherList = await _weatherService.GetWeatherByLocationAsync(location.Key);
                    var locationWeather = new LocationWeather
                    {
                        Location = location,
                        CurrentWeather = weatherList.FirstOrDefault()
                    };

                    LocationWeatherList.Add(locationWeather);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}