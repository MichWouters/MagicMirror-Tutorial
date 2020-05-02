using MagicMirror.DataAccess.Configuration;
using MagicMirror.DataAccess.Entities.Traffic;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public class GoogleMapsRepo : Repository<GoogleMapsTrafficEntity>, IGoogleMapsRepo
    {
        private string _start;
        private string _destination;

        public async Task<GoogleMapsTrafficEntity> GetTrafficInfoAsync(string start, string destination)
        {
            Url = GenerateApiEndpoint(start, destination);
            HttpResponseMessage message = await GetHttpResponseMessageAsync();
            GoogleMapsTrafficEntity entity = await GetEntityFromJsonAsync(message);

            if (entity.Rows[0].Elements[0].Distance == null)
            {
                throw new HttpRequestException("Unable to retrieve traffic information");
            }

            return entity;
        }

        protected override string GenerateApiEndpoint(string start, string destination)
        {
            ApiId = DataAccessConfig.GoogleMapsApiId;
            ApiUrl = DataAccessConfig.GoogleMapsApiUrl;
            _start = start;
            _destination = destination;

            ValidateInput();

            return $"{ApiUrl}?origins={start}&destinations={destination}&key={ApiId}";
        }

        protected override void ValidateInput()
        {
            base.ValidateInput();

            if (string.IsNullOrWhiteSpace(_start)) { throw new ArgumentNullException("A start location has to be provided"); }
            if (string.IsNullOrWhiteSpace(_destination)) { throw new ArgumentNullException("A destination has to be provided"); }
        }
    }
}