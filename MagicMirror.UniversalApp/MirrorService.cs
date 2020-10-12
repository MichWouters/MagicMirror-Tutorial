using AutoMapper;
using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.UniversalApp.Models;
using MagicMirror.UniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMirror.UniversalApp
{
    public class MirrorService : IMirrorService
    {
        // Services
        private readonly IWeatherService _weatherService;
        private readonly ITrafficService _trafficService;
        private readonly IMapper _mapper;

        public MirrorService(IWeatherService weatherService, ITrafficService trafficService, IMapper mapper)
        {
            _weatherService = weatherService;
            _trafficService = trafficService;
            _mapper = mapper;
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
                Distance = 27.5,
                DistanceUom = DistanceUom.Metric,
                Destination = "2 St Margaret St, London",
                TimeOfArrival = DateTime.Now.AddMinutes(35),
            };
        }
    }
}
