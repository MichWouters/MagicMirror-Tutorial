using MagicMirror.DataAccess.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace MagicMirror.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Dependency Injection
            var services = new ServiceCollection();
            services.AddTransient<IWeatherRepo, WeatherRepo>();

            var main = new Main();
            main.Run();
        }
    }
}