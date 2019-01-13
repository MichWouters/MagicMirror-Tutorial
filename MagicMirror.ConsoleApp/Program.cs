using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace MagicMirror.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Initialize Automapper configuration
            Configuration.AutoMapperConfiguration.RegisterMaps();

            var main = new Main();
            main.RunAsync().GetAwaiter().GetResult();
        }
    }
}