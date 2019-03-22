using AutoMapper;
using MagicMirror.Business.Configuration;
using MagicMirror.ConsoleApp.Configuration;

namespace MagicMirror.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var main = new Main();
            main.RunAsync();
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