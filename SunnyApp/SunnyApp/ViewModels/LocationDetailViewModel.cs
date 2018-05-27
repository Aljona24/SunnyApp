using System;

using SunnyApp.Models;

namespace SunnyApp.ViewModels
{
    public class LocationDetailViewModel : BaseViewModel
    {
        public Location Location { get; set; }
        public LocationDetailViewModel(Location location)
        {
            Title = location?.LocalizedName;
            Location = location;
        }
    }
}
