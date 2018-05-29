using MagicMirror.DataAccess.Configuration;
using MagicMirror.DataAccess.Entities.Traffic;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public class TrafficRepo : ITrafficRepo
    {
        private string _apiId;
        private string _apiUrl;
        private string _url;

        private string _start;
        private string _destination;

        public async Task<TrafficEntity> GetTrafficInfoAsync(string start, string destination)
        {
            FillInputData(start, destination);
            HttpResponseMessage message = await GetHttpResponseMessageAsync();
            TrafficEntity entity = await GetEntityFromJsonAsync(message);

            return entity;
        }

        private void FillInputData(string start, string destination)
        {
            _apiId = DataAccessConfig.TrafficApiId;
            _apiUrl = DataAccessConfig.TrafficApiUrl;
            _start = start;
            _destination = destination;

            ValidateInput();

            _url = $"{_apiUrl}?origins={start}&destinations={destination}&key={_apiId}";
        }

        private void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(_apiId)) { throw new ArgumentNullException("An apiKey has to be provided"); }
            if (string.IsNullOrWhiteSpace(_apiUrl)) { throw new ArgumentNullException("An apiUrl has to be provided"); }

            if (string.IsNullOrWhiteSpace(_start)) { throw new ArgumentNullException("A start location has to be provided"); }
            if (string.IsNullOrWhiteSpace(_destination)) { throw new ArgumentNullException("A destination has to be provided"); }
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

        private async Task<TrafficEntity> GetEntityFromJsonAsync(HttpResponseMessage message)
        {
            string json = await message.Content.ReadAsStringAsync();

            try
            {
                var result = JsonConvert.DeserializeObject<TrafficEntity>(json);
                return result;
            }
            catch (Exception e)
            {
                throw new JsonSerializationException("Cannot convert from entity", e);
            }
        }
    }
}