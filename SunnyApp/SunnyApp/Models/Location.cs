using System;

namespace SunnyApp.Models
{
    public class Location
    {
        public string Key { get; set; }
        public string LocalizedName { get; set; } 
        public Country Country { get; set; }
    }
}