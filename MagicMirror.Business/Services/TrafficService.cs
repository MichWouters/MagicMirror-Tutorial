using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Repos;
using System;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class TrafficService : Service<TrafficModel>, ITrafficService
    {
        private ITrafficRepo _repo;

        public TrafficService(ITrafficRepo repo)
        {
            // Dependency Injection
            _repo = repo;
        }

        public Task<TrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            throw new NotImplementedException();
        }
    }
}