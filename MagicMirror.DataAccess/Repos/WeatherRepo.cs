using MagicMirror.DataAccess.Configuration;
using MagicMirror.DataAccess.Entities.Weather;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public class WeatherRepo : Repository<WeatherEntity>, IWeatherRepo
    {
        private string _city;

        public async Task<WeatherEntity> GetWeatherEntityByCityAsync(string city)
        {
            FillInputData(city);
            HttpResponseMessage message = await GetHttpResponseMessageAsync();
            WeatherEntity entity = await GetEntityFromJsonAsync(message);

            return entity;
        }

        private void FillInputData(string city)
        {
            _apiId = DataAccessConfig.OpenWeatherMapApiId;
            _apiUrl = DataAccessConfig.OpenWeatherMapApiUrl;
            _city = city;

            ValidateInput();

            _url = $"{_apiUrl}/weather?q={_city}&appId={_apiId}";
        }

        protected override void ValidateInput()
        {
            base.ValidateInput();
            if (string.IsNullOrWhiteSpace(_city)) { throw new ArgumentNullException("A home city has to be provided"); }
        }
    }
}