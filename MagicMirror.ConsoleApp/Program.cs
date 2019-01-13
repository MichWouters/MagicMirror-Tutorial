using MagicMirror.Business.Configuration;
using MagicMirror.ConsoleApp.Configuration;

namespace MagicMirror.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var main = new Main();
            main.RunAsync();
        }

        private static void RegisterAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperBusinessProfile>();
                cfg.AddProfile<AutoMapperPresentationProfile>();
            });
        }
    }
}