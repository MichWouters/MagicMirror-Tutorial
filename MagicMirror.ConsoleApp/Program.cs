﻿namespace MagicMirror.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var main = new Main();
            main.RunAsync().GetAwaiter().GetResult();

        }
    }
}