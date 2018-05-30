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
            return RequestBuilder.BuildGetRequest("http://dataservice.accuweather.com")
                .SetPathPart($"forecasts/v1/hourly/1hour/{locationKey}")
                .AddQueryStringParameter("apikey", "JN3fCDgzMkUOpEqZU0yAXKAEezj1p2Ew")
                .AddQueryStringParameter("details", "true")
                .AddQueryStringParameter("metric", "true")
                .GetAsync<IList<Weather>>();
        }
    }
}