namespace MagicMirror.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Initialize Automapper configuration
            Configuration.AutoMapperConfiguration.RegisterMaps();

            var main = new Main();
            main.RunAsync().GetAwaiter().GetResult();
        }
    }
}