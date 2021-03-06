﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyApp.Models;
using SunnyApp.ApiRequestHelper;
using SunnyApp.Repositories.AccuWeatherRepositories.Abstractions;

namespace SunnyApp.Repositories.AccuWeatherRepository
{
    public class WeatherAccuWeatherRepository : BaseAccuWeatherRepository, IWeatherAccuWeatherRepository
    {
        public Task<IList<Weather>> GetWeatherByLocationAsync(string locationKey)
        {
            return RequestBuilder.BuildGetRequest($"{BaseUrI}")
                .SetPathPart($"forecasts/v1/hourly/1hour/{locationKey}")
                .AddQueryStringParameter("apikey", $"{ApiKey}")
                .AddQueryStringParameter("details", "true")
                .AddQueryStringParameter("metric", "true")
                .GetAsync<IList<Weather>>();
        }
    }
}