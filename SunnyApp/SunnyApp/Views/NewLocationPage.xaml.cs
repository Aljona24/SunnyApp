using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SunnyApp.Models;

namespace SunnyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewLocationPage : ContentPage
    {
        public Location Item { get; set; } 

        public NewLocationPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}