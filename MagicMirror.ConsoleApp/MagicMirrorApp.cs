using Acme.Generic.Helpers;
using AutoMapper;
using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.ConsoleApp.Models;
using System;
using System.Threading.Tasks;

namespace MagicMirror.ConsoleApp
{
    public class MagicMirrorApp
    {
        // Services
        private readonly IWeatherService _weatherService;
        private readonly ITrafficService _trafficService;
        private readonly IMapper _mapper;

        public MagicMirrorApp(IWeatherService weatherService, ITrafficService trafficService, IMapper mapper)
        {
            _weatherService = weatherService;
            _trafficService = trafficService;
            _mapper = mapper;
        }

        public async Task RunAsync()
        {
            UserSettings information = GetInformation();

            try
            {
                MainViewModel model = await GenerateViewModel(information);
                GenerateOutput(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                Console.ReadLine();
            }
        }

        public async Task<MainViewModel> GenerateViewModel(UserSettings information)
        {
            var model = new MainViewModel();
            WeatherModel weatherModel;
            TrafficModel trafficModel;

            try
            {
                weatherModel = await GetWeatherModelAsync(information.Town);
                trafficModel = await GetTrafficModelAsync($"{information.Address}, {information.Town}", information.WorkAddress);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred. Displaying offline data");
                Console.WriteLine(ex.ToString());

                weatherModel = GetOfflineWeatherData();
                trafficModel = GetOfflineTrafficData();
                model.IsOfflineData = true;
            }

            // Map models to ViewModel
            model = _mapper.Map(weatherModel, model);
            model = _mapper.Map(trafficModel, model);
            model.UserName = information?.Name ?? "Anonymous";

            return model;
        }

        private async Task<WeatherModel> GetWeatherModelAsync(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException(nameof(city));
            }

            WeatherModel model = await _weatherService.GetWeatherModelAsync(city);
            return model;
        }

        private async Task<TrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            if (string.IsNullOrEmpty(origin))
            {
                throw new ArgumentNullException(nameof(origin));
            }

            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentNullException(nameof(destination));
            }

            TrafficModel model = await _trafficService.GetTrafficModelAsync(origin, destination);
            return model;
        }

        private UserSettings GetInformation()
        {
            var user = UserSettings.GetUserSettings();

            Console.WriteLine("Please enter your name:");
            user.Name = Console.ReadLine();

            Console.WriteLine("Please enter your street and number:");
            user.Address = Console.ReadLine();

            Console.WriteLine("Please enter your zipcode:");
            user.Zipcode = Console.ReadLine();

            Console.WriteLine("Please enter your town:");
            user.Town = Console.ReadLine();

            Console.WriteLine("Please enter your work address:");
            user.WorkAddress = Console.ReadLine();

            return user;
        }

        private void GenerateOutput(MainViewModel model)
        {
            Console.WriteLine($"Good {DateTimeHelper.GetTimeOfDay()} {model.UserName}");
            Console.WriteLine($"The current time is {DateTime.Now.ToShortTimeString()} and the outside weather is {model.WeatherType}.");
            Console.WriteLine($"Current topside temperature is {model.Temperature} degrees {model.TemperatureUom}.");
            Console.WriteLine($"The sun has risen at {model.Sunrise} and will set at approximately {model.Sunset}.");
            Console.WriteLine($"Your trip to work is about {model.Distance} {model.DistanceUom} long and will take about {model.TravelTime }.");
            Console.WriteLine($"If you leave now, you should arrive at approximately { model.TimeOfArrival }.");
            Console.WriteLine("Thank you, and have a very safe and productive day!");
        }

        private WeatherModel GetOfflineWeatherData()
        {
            return new WeatherModel
            {
                Location = "London",
                Temperature = 17,
                Sunrise = new DateTime(2019, 10, 10, 6, 4, 0),
                Sunset = new DateTime(2019, 10, 10, 18, 36, 0),
                WeatherType = "Sunny",
                TemperatureUom = TemperatureUom.Celsius,
            };
        }

        private TrafficModel GetOfflineTrafficData()
        {
            return new TrafficModel
            {
                Duration = 35 * 60,
                Distance = 27500,
                DistanceUom = DistanceUom.Metric,
                Destination = "2 St Margaret St, London",
                TimeOfArrival = DateTime.Now.AddMinutes(35),
            };
        }
    }
}