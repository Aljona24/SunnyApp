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
	public partial class LocationListPage : ContentPage
	{
	    LocationListViewModel viewModel;

        public LocationListPage()
        {
            InitializeComponent();

            //BindingContext = viewModel = new LocationListViewModel();
            BindingContext = viewModel = App.Container.Resolve<LocationListViewModel>();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Location;
            if (item == null)
                return;

            await Navigation.PushAsync(new LocationDetailPage(new LocationDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewLocationPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.LocationWeatherList.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}