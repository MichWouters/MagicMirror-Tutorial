using MagicMirror.DataAccess.Configuration;
using MagicMirror.DataAccess.Entities.Traffic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public class OpenTrafficMapRepo : Repository<OpenMapTrafficEntity>, ITrafficRepo<OpenMapTrafficEntity>
    {
        private string _start;
        private string _destination;

        public async Task<OpenMapTrafficEntity> GetTrafficInfoAsync(string start, string destination)
        {
            FillInputData(start, destination);
            HttpResponseMessage message = await GetHttpResponseMessageAsync();
            OpenMapTrafficEntity entity = await GetEntityFromJsonAsync(message);

            return entity;
        }

        private void FillInputData(string start, string destination)
        {
            _apiId = DataAccessConfig.OpenMapApiId;
            _apiUrl = DataAccessConfig.OpenMapApiTrafficUrl;
            _start = start;
            _destination = destination;

            ValidateInput();

            _url = $"{_apiUrl}?key={_apiId}&from={start}&to={destination}";
        }
    }
}