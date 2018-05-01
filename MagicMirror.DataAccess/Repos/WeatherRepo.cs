using MagicMirror.DataAccess.Configuration;
using MagicMirror.DataAccess.Entities.Weather;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public class WeatherRepo
    {
        private string _apiId;
        private string _apiUrl;
        private string _url;

        private string _city;

        private async Task<WeatherEntity> GetWeatherEntityByCityAsync(string city)
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

        private void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(_apiId)) { throw new ArgumentNullException("An apiKey has to be provided"); }
            if (string.IsNullOrWhiteSpace(_apiUrl)) { throw new ArgumentNullException("An apiUrl has to be provided"); }
            if (string.IsNullOrWhiteSpace(_city)) { throw new ArgumentNullException("A home city has to be provided"); }
        }

        private async Task<HttpResponseMessage> GetHttpResponseMessageAsync()
        {
            var client = new HttpClient();

            HttpResponseMessage message = await client.GetAsync(_url);

            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Cannot connect to api: {message.StatusCode} {message.ReasonPhrase}");
            }

            return message;
        }

        private async Task<WeatherEntity> GetEntityFromJsonAsync(HttpResponseMessage message)
        {
            string json = await message.Content.ReadAsStringAsync();

            try
            {
                var result = JsonConvert.DeserializeObject<WeatherEntity>(json);
                return result;
            }
            catch (Exception e)
            {
                throw new JsonSerializationException("Cannot convert from entity", e);
            }
        }
    }
}