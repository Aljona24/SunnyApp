using System;
using System.Collections.Generic;
using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SunnyApp.Models;

namespace SunnyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewLocationPage : ContentPage
    {
        public Location Item { get; set; }
        LocationListViewModel viewModel;

        public NewLocationPage()
        {
            InitializeComponent();

            //BindingContext = viewModel = new LocationListViewModel();
            BindingContext = viewModel = App.Container.Resolve<LocationListViewModel>();
            //
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Location;
            if (item == null)
                return;
            Item = item;
            // Manually deselect item.
            ItemsListView.SelectedItem = null;

            Save_Clicked(sender, args); //todo args?
        }
    }
}