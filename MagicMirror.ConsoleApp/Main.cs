using Acme.Generic.Helpers;
using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.ConsoleApp.Models;
using System;
using System.Threading.Tasks;

namespace MagicMirror.ConsoleApp
{
    public class Main
    {
        private MainViewModel _model;
        private readonly IWeatherService _weatherService;
        private readonly ITrafficService _trafficService;

        public Main(IWeatherService weatherService, ITrafficService trafficService)
        {
            _weatherService = weatherService;
            _trafficService = trafficService;
            _model = new MainViewModel();
        }

        public async Task RunAsync()
        {
            UserInformation information = GetInformation();

            try
            {
                WeatherModel weatherModel;
                TrafficModel trafficModel;

                try
                {
                    weatherModel = await GetWeatherModelAsync(information.Town);
                    trafficModel = await GetTrafficModelAsync($"{information.Address}, {information.Town}",
                        information.WorkAddress);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occurred while fetching data. Displaying offline data");
                    Console.WriteLine(e.ToString());

                    weatherModel = GetOfflineWeatherData();
                    trafficModel = GetOfflineTrafficData();
                }

                _model = AutoMapper.Mapper.Map(weatherModel, _model);
                _model = AutoMapper.Mapper.Map(trafficModel, _model);

                _model.UserName = information.Name;
                _model.TimeOfDay = DateTimeHelper.GetTimeOfDay();

                GenerateOutput();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private async Task<WeatherModel> GetWeatherModelAsync(string city)
        {
            if (string.IsNullOrEmpty(city))
                throw new ArgumentNullException(nameof(city));

            var model = await _weatherService.GetWeatherModelAsync(city);
            return model;
        }

        private async Task<TrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            if (string.IsNullOrEmpty(origin))
                throw new ArgumentNullException(nameof(origin));

            if (string.IsNullOrEmpty(destination))
                throw new ArgumentNullException(nameof(destination));

            var model = await _trafficService.GetTrafficModelAsync(origin, destination);
            return model;
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

        private void GenerateOutput()
        {
            Console.WriteLine($"Good {_model.TimeOfDay} {_model.UserName}");
            Console.WriteLine($"The current time is {DateTime.Now.ToShortTimeString()} and the outside weather is {_model.WeatherType}.");
            Console.WriteLine($"Current topside temperature is {_model.Temperature} degrees {_model.TemperatureUom}.");
            Console.WriteLine($"The sun has risen at {_model.Sunrise} and will set at approximately {_model.Sunset}.");
            Console.WriteLine($"Your trip to work will take about {_model.TravelTime}." +
                $"If you leave now, you should arrive at approximately {_model.TimeOfArrival}.");
            Console.WriteLine("Thank you, and have a very safe and productive day!");
        }

        #region Fallback Methods

        private WeatherModel GetOfflineWeatherData()
        {
            return new WeatherModel
            {
                Location = "London",
                Sunrise = "6:04",
                Sunset = "18:36",
                Temperature = 17,
                WeatherType = "Sunny",
                TemperatureUom = TemperatureUom.Celsius
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

        #endregion Fallback Methods
    }
}