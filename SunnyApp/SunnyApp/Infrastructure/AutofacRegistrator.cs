using Autofac;
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

            builder.RegisterType<LocationRepository>().As<ILocationRepository>();
            builder.RegisterType<WeatherRepository>().As<IWeatherRepository>();
        }
    }
}
