using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SunnyApp.Models;
using SunnyApp.ApiRequestHelper;
using SunnyApp.Repositories.Abstractions;

namespace SunnyApp.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        public Task<Weather> GetWeatherByLocationAsync(string locationKey)
        {
            return RequestBuilder.BuildGetRequest("http://dataservice.accuweather.com/forecasts/v1/hourly/1hour/")
                .SetPathPart($"{locationKey}")
                .AddQueryStringParameter("apikey", "wJxBCJ6VUaN4TFVRTKzmn3RGuWx0FbWb")
                .AddQueryStringParameter("details", "true")
                .AddQueryStringParameter("metric", "true")
                .GetAsync<Weather>();
        }
    }
}
