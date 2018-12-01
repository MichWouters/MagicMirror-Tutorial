using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace MagicMirror.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            Configuration.MappingConfigs.RegisterMaps();

            // Entry to run app
            serviceProvider.GetService<Main>()
                .RunAsync().GetAwaiter().GetResult();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Add Services
            serviceCollection.AddTransient<ITrafficService, TrafficService>();
            serviceCollection.AddTransient<ITrafficRepo, TrafficRepo>();
            serviceCollection.AddTransient<IWeatherService, WeatherService>();
            serviceCollection.AddTransient<IWeatherRepo, WeatherRepo>();

            // Add app
            serviceCollection.AddTransient<Main>();
        }
    }
}