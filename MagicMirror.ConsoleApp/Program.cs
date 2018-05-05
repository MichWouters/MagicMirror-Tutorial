using MagicMirror.DataAccess.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace MagicMirror.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var main = new Main();
            main.Run();
        }
    }
}