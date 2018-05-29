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
        private readonly ILocationSearchService _locationSearchServiceService;
        private string _searchedText;

        public ObservableCollection<Location> LocationList { get; set; }
        public Command LoadItemsCommand { get; set; }
        public string SearchedText
        {
            get => _searchedText;
            set { _searchedText = value; OnPropertyChanged(); }
        }

        public LocationListViewModel(ILocationSearchService locationSearchService)
        {
            _locationSearchServiceService = locationSearchService;
            Title = "Browse";
            LocationList = new ObservableCollection<Location>();
            LoadItemsCommand = new Command(async () => await ExecuteSearchLocationListCommandAsync());
        }

        async Task ExecuteSearchLocationListCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                LocationList.Clear();
                var locationList = await _locationSearchServiceService.GetLocationListByTextAsync(SearchedText);
                foreach (var location in locationList)
                {
                    LocationList.Add(location);
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