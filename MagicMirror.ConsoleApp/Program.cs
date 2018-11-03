namespace MagicMirror.ConsoleApp
{
    internal class Program
    {
        private static async void Main(string[] args)
        {
            var main = new Main();
            await main.RunAsync();
        }
    }
}