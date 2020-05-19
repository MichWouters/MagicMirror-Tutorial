using MagicMirror.DataAccess.Configuration;
using MagicMirror.DataAccess.Entities.Entities;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public class MapQuestTrafficRepo : Repository<MapQuestTrafficEntity>, IMapQuestTrafficRepo
    {
        private string _start;
        private string _destination;

        public async Task<MapQuestTrafficEntity> GetTrafficInfoAsync(string start, string destination)
        {
            _url = GenerateApiEndpoint(start, destination);
            HttpResponseMessage message = await GetHttpResponseMessageAsync();
            MapQuestTrafficEntity entity = await GetEntityFromJsonAsync(message);

            if (entity.Info.Statuscode != 0)
            {
                throw new HttpRequestException("Unable to retrieve traffic information");
            }

            return entity;
        }

        private string GenerateApiEndpoint(string start, string destination)
        {
            _apiId = DataAccessConfig.MapQuestApiId;
            _apiUrl = DataAccessConfig.MapQuestApiUrl;
            _start = start;
            _destination = destination;

            ValidateInput();

            return $"{_apiUrl}?from={start}&to={destination}&key={_apiId}";
        }

        protected override void ValidateInput()
        {
            base.ValidateInput();
            if (string.IsNullOrWhiteSpace(_start)) { throw new ArgumentNullException("A start location has to be provided"); }
            if (string.IsNullOrWhiteSpace(_destination)) { throw new ArgumentNullException("A destination has to be provided"); }
        }
    }
}