using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SunnyApp.Models;
using SunnyApp.Views;
using SunnyApp.ViewModels;

namespace SunnyApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocationWeatherListPage : ContentPage
	{
	    LocationWeatherListViewModel viewModel;

        public LocationWeatherListPage()
        {
            InitializeComponent();

            //BindingContext = viewModel = new LocationListViewModel();
            BindingContext = viewModel = App.Container.Resolve<LocationWeatherListViewModel>();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as LocationWeather;
            if (item == null)
                return;

            await Navigation.PushAsync(new LocationDetailPage(new LocationDetailViewModel(item.Location)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SearchLocationListPage()));
        }
	    void RefreshItem_Clicked(object sender, EventArgs e)
	    {
	        viewModel.LoadItemsCommand.Execute(null);
        }
        void RemoveLocation_Clicked(object sender, EventArgs e)
	    {
	        if (ItemsListView.ItemsSource is IList<LocationWeather> selectedItem)
	        {
	            viewModel.RemoveItemCommand.Execute(selectedItem[0].Location.Key);
	        }
            ItemsListView.SelectedItem = null;

	    }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.LocationWeatherList.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}