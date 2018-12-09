namespace MagicMirror.ConsoleApp
{
    internal class Program
    {
        private static async System.Threading.Tasks.Task Main(string[] args)
        {
            var main = new Main();
            await main.RunAsync();
        }
    }
}