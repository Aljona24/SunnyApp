using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SunnyApp.Models;
using SunnyApp.ViewModels;

namespace SunnyApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocationDetailPage : ContentPage
	{
        LocationDetailViewModel viewModel;

	    public LocationDetailPage(LocationDetailViewModel viewModel)
	    {
	        InitializeComponent();

	        BindingContext = this.viewModel = viewModel;
	    }
	}
}