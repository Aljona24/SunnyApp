using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SunnyApp.ApiRequestHelper.Exceptions;
using Xamarin.Forms;
using SunnyApp.Models;
using SunnyApp.Services.Abstractions;
using SunnyApp.Views;
using Windows.UI.Xaml;
using SunnyApp.Repositories.Abstractions;

namespace SunnyApp.ViewModels
{
    public class SearchLocationListViewModel : BaseViewModel
    {
        private readonly ILocationSearchService _locationSearchServiceService;
        private string _searchedText;

        public SearchLocationListViewModel(ILocationSearchService locationSearchService)
        {
            _locationSearchServiceService = locationSearchService;
            Title = "Browse";
            LocationList = new ObservableCollection<Location>();
            LoadItemsCommand = new Command(async () => await ExecuteSearchLocationListCommandAsync());
        }

        public ObservableCollection<Location> LocationList { get; set; }
        public Command LoadItemsCommand { get; set; }

        public string SearchedText
        {
            get => _searchedText;
            set => SetProperty(ref _searchedText, value);
        }

        private async Task ExecuteSearchLocationListCommandAsync()
        {
            await ExecuteCommandAsync(async () =>
            {
                LocationList.Clear();
                var locationList = await _locationSearchServiceService.GetLocationListByTextAsync(SearchedText);
                foreach (var location in locationList)
                {
                    LocationList.Add(location);
                }

                ErrorMessage = string.Empty;
                IsErrorMessageVisible = false;
                IsListVisible = true;
            });
        }

    }
}