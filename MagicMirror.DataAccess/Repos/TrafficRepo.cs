using System;
using System.Threading.Tasks;
using MagicMirror.DataAccess.Entities.Traffic;

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
            throw new NotImplementedException();
        }
    }
}