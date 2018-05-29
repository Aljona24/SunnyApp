using System;
using System.Collections.Generic;
using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SunnyApp.Models;
using SunnyApp.ViewModels;

namespace SunnyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewLocationPage : ContentPage
    {
        private LocationListViewModel _viewModel;

        public NewLocationPage()
        {
            InitializeComponent();

            //BindingContext = viewModel = new LocationListViewModel();
            BindingContext = _viewModel = App.Container.Resolve<LocationListViewModel>();
            //
            //BindingContext = this;
        }

        //async void Save_Clicked(object sender, EventArgs e)
        //{
        //    MessagingCenter.Send(this, "AddItem", _location);
        //    await Navigation.PopModalAsync();
        //}

        async void OnItemSelected_AddItem(object sender, SelectedItemChangedEventArgs args)
        {
            var location = args.SelectedItem as Location;
            if (location == null)
                return;
            // Manually deselect item.
            //ItemsListView.SelectedItem = null;

            MessagingCenter.Send(this, "AddItem", location);
            await Navigation.PopModalAsync();
        }
    }
}