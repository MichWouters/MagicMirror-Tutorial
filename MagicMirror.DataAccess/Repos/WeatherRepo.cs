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
            Url = GenerateApiEndpoint(city, string.Empty);
            HttpResponseMessage message = await GetHttpResponseMessageAsync();
            WeatherEntity entity = await GetEntityFromJsonAsync(message);

            return entity;
        }

        protected override void ValidateInput()
        {
            base.ValidateInput();
            if (string.IsNullOrWhiteSpace(_city)) { throw new ArgumentNullException("A home city has to be provided"); }
        }

        protected override string GenerateApiEndpoint(string start, string destination)
        {
            ApiId = DataAccessConfig.OpenWeatherMapApiId;
            ApiUrl = DataAccessConfig.OpenWeatherMapApiUrl;
            _city = start;

            ValidateInput();

            return $"{ApiUrl}/weather?q={_city}&appId={ApiId}";
        }
    }
}