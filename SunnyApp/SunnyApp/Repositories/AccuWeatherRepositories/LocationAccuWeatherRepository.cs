using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunnyApp.ApiRequestHelper;
using SunnyApp.Models;
using SunnyApp.Repositories.Abstractions;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(SunnyApp.Repositories.LocationAccuWeatherRepository))]
namespace SunnyApp.Repositories
{
    public class LocationAccuWeatherRepository : BaseAccuWeatherRepository, ILocationRepository
    {
        public Task<IList<Location>> GetLocationListByTextAsync(string searchText)
        {
            return RequestBuilder.BuildGetRequest($"{BaseUrI}")
                .SetPathPart($"locations/v1/search")
                .AddQueryStringParameter("apikey", $"{ApiKey}") 
                .AddQueryStringParameter("q", $"{searchText}")
                .GetAsync<IList<Location>>();
        }
    }
}