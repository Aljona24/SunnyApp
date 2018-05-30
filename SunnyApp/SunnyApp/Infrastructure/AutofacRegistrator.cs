using Autofac;
using SunnyApp.Models;
using SunnyApp.Repositories;
using SunnyApp.Repositories.Abstractions;
using SunnyApp.Services;
using SunnyApp.Services.Abstractions;
using SunnyApp.ViewModels;


namespace SunnyApp.Infrastructure
{
    public static class AutofacRegistrator
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<LocationWeatherListViewModel>().AsSelf();
            builder.RegisterType<SearchLocationListViewModel>().AsSelf();

            builder.RegisterType<LocationSearchService>().As<ILocationSearchService>();
            builder.RegisterType<WeatherService>().As<IWeatherService>();

            builder.RegisterType<LocationAccuWeatherRepository>().As<ILocationRepository>();
            builder.RegisterType<WeatherAccuWeatherRepository > ().As<IWeatherRepository>();
            builder.RegisterType<LocationDataStoreRepository>().As<IDataStore<Location>>();
        }
    }
}
