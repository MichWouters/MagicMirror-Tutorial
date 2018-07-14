using MagicMirror.Business.Services;
using MagicMirror.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using MagicMirror.DataAccess.Repos;

namespace MagicMirror.Tests.Weather
{
    public class WeatherBusinessTests
    {
        private IWeatherService _service;

        private const string Location = "London";
        private const double Kelvin = 295.15;
        private const string Weathertype = "Clear";
        private const string Icon = "01d";
        private const int Sunrise = 1531281435;
        private const int Sunset = 1531340063;

        public WeatherBusinessTests()
        {
            var mockInterface = new Mock<IWeatherRepo>();
            _service = new WeatherService(mockInterface.Object);
        }
    }
}
