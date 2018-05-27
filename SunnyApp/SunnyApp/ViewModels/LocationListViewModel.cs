using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using SunnyApp.Models;
using SunnyApp.Views;

namespace SunnyApp.ViewModels
{
    public class LocationListViewModel : BaseViewModel
    {
        public ObservableCollection<Location> Locations { get; set; }
        public Command LoadItemsCommand { get; set; }

        public LocationListViewModel()
        {
            Title = "Browse";
            Locations = new ObservableCollection<Location>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewLocationPage, Location>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Location;
                Locations.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Locations.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Locations.Add(item);
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