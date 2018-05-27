using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyApp.Models;
using SunnyApp.ApiRequestHelper;
using SunnyApp.Repositories.Abstractions;

namespace SunnyApp.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        public Task<IList<Weather>> GetWeatherByLocationAsync(string locationKey)
        {
            // TODO: move to constant
            return RequestBuilder.BuildGetRequest("http://dataservice.accuweather.com")
                .SetPathPart($"forecasts/v1/hourly/1hour/{locationKey}")
                .AddQueryStringParameter("apikey", "wJxBCJ6VUaN4TFVRTKzmn3RGuWx0FbWb")
                .AddQueryStringParameter("details", "true")
                .AddQueryStringParameter("metric", "true")
                .GetAsync<IList<Weather>>();
        }
    }
}