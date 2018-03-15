using MagicMirror.ConsoleApp.Models;
using System;

namespace MagicMirror.ConsoleApp
{
    public class Main
    {
        private UserInformation _userInformation;
        private WeatherInformation _weatherInformation;
        private TrafficInformation _trafficInformation;

        public void Run()
        {
            _userInformation = GetInformation();
            _weatherInformation = GetOfflineWeatherData();
            _trafficInformation = GetOfflineTrafficData();

            GenerateOutput();
            Console.ReadLine();
        }

        private UserInformation GetInformation()
        {
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter your street and number:");
            string address = Console.ReadLine();

            Console.WriteLine("Please enter your zipcode:");
            string zipcode = Console.ReadLine();

            Console.WriteLine("Please enter your town:");
            string town = Console.ReadLine();

            Console.WriteLine("Please enter your work address:");
            string workAddress = Console.ReadLine();

            var result =  new UserInformation
            {
                Name = name,
                Address = address,
                Zipcode = zipcode,
                Town = town,
                WorkAddress = workAddress
            };

            return result;
        }

        private WeatherInformation GetOfflineWeatherData()
        {
            return new WeatherInformation
            {
                Location = "London",
                Sunrise = "6:04",
                Sunset = "18:36",
                Temperature = 17,
                WeatherType = "Sunny",
                TemperatureUOM = "Celsius",
            };
        }

        private TrafficInformation GetOfflineTrafficData()
        {
            return new TrafficInformation
            {
                Minutes = 35,
                Distance = 27,
                DistanceUOM = "Kilometers",
                Destination = "2 St Margaret St, London"
            };
        }

        private void GenerateOutput()
        {
            Console.WriteLine($"Good {GetTimeOfDay()} {_userInformation.Name}");
            Console.WriteLine($"The current time is {DateTime.Now.ToShortTimeString()} and the outside weather is {_weatherInformation.WeatherType}.");
            Console.WriteLine($"Current topside temperature is {_weatherInformation.Temperature} degrees {_weatherInformation.TemperatureUOM}.");
            Console.WriteLine($"The sun has risen at {_weatherInformation.Sunrise} and will set at approximately {_weatherInformation.Sunset}.");
            Console.WriteLine($"Your trip to work will take about {_trafficInformation.Minutes} minutes. " +
                $"If you leave now, you should arrive at approximately {_trafficInformation.TimeOfArrival.ToShortTimeString()}.");
            Console.WriteLine("Thank you, and have a very safe and productive day!");
        }

        private string GetTimeOfDay()
        {
            var currentTime = DateTime.Now.TimeOfDay.Hours;

            if (currentTime >= 0 && currentTime <= 11)
                return "morning";
            else if (currentTime <= 13)
                return "day";
            else if (currentTime <= 18)
                return "afternoon";
            else if (currentTime <= 22)
                return "evening";
            else
                return "night";
        }
    }
}