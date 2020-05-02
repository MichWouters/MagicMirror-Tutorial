using MagicMirror.DataAccess.Configuration;
using MagicMirror.DataAccess.Entities.Entities;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public class OpenMapTrafficRepo : Repository<OpenMapTrafficEntity>, IOpenMapTrafficRepo
    {
        private string _start;
        private string _destination;

        public async Task<OpenMapTrafficEntity> GetTrafficInfoAsync(string start, string destination)
        {
            Url = GenerateApiEndpoint(start, destination);
            HttpResponseMessage message = await GetHttpResponseMessageAsync();
            OpenMapTrafficEntity entity = await GetEntityFromJsonAsync(message);

            return entity;
        }

        protected override string GenerateApiEndpoint(string start, string destination)
        {
            ApiId = DataAccessConfig.OpenMapApiId;
            ApiUrl = DataAccessConfig.OpenMapApiTrafficUrl;

            _start = start;
            _destination = destination;

            ValidateInput();

            return $"{ApiUrl}?key={ApiId}&from={_start}&to={_destination}";
        }

        protected override void ValidateInput()
        {
            base.ValidateInput();

            if (string.IsNullOrWhiteSpace(_start)) { throw new ArgumentNullException(nameof(_start)); }
            if (string.IsNullOrWhiteSpace(_destination)) { throw new ArgumentNullException(nameof(_destination)); }
        }
    }
}