using AutoMapper;
using MagicMirror.Business.Configuration;
using MagicMirror.Business.Services;
using MagicMirror.ConsoleApp.Configuration;
using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MagicMirror.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            RegisterServices(services);
            RegisterAutoMapper();

            ServiceProvider provider = services.BuildServiceProvider();
            provider.GetService<MagicMirrorApp>().RunAsync().GetAwaiter().GetResult();
        }

        private static void RegisterServices(ServiceCollection services)
        {
            // Add Services using Dependency Injection
            services.AddTransient<ITrafficService, TrafficService>();
            services.AddTransient<ITrafficRepo<OpenMapTrafficEntity>, OpenTrafficMapRepo>();
            services.AddTransient<IWeatherService, WeatherService>();
            services.AddTransient<IWeatherRepo, WeatherRepo>();

            // Register App
            services.AddSingleton<MagicMirrorApp>();

            // Register AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void RegisterAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperBusinessProfile>();
                cfg.AddProfile<AutoMapperPresentationProfile>();
            });
        }
    }
}