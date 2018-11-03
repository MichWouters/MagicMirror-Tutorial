﻿using Acme.Generic.Helpers;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Models;
using System;
using MagicMirror.Business.Enums;

namespace MagicMirror.ConsoleApp
{
    public class Main
    {
        private MainViewModel model;

        public void Run()
        {
            model = new MainViewModel();
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

            var result = new UserInformation
            {
                Name = name,
                Address = address,
                Zipcode = zipcode,
                Town = town,
                WorkAddress = workAddress
            };

            return result;
        }

        private WeatherModel GetOfflineWeatherData()
        {
            return new WeatherModel
            {
                Location = "London",
                Sunrise = "6:04",
                Sunset = "18:36",
                Temperature = 17,
                WeatherType = "Sunny",
                TemperatureUom =  TemperatureUom.Celsius
            };
        }

        private TrafficModel GetOfflineTrafficData()
        {
            return new TrafficModel
            {
                Duration = 35,
                Distance = 27,
                DistanceUom = DistanceUom.Imperial,
                Destination = "2 St Margaret St, London"
            };
        }

        private void GenerateOutput()
        {
            Console.WriteLine($"Good {DateTimeHelper.GetTimeOfDay()} {model.User.Name}");
            Console.WriteLine($"The current time is {DateTime.Now.ToShortTimeString()} and the outside weather is {model.Weather.WeatherType}.");
            Console.WriteLine($"Current topside temperature is {model.Weather.Temperature} degrees {model.Weather.TemperatureUom.ToString()}.");
            Console.WriteLine($"The sun has risen at {model.Weather.Sunrise} and will set at approximately {model.Weather.Sunset}.");
            Console.WriteLine($"Your trip to work will take about {model.Traffic.Duration} minutes. " +
                $"If you leave now, you should arrive at approximately {model.Traffic.TimeOfArrival.ToShortTimeString()}.");
            Console.WriteLine("Thank you, and have a very safe and productive day!");
        }
    }
}