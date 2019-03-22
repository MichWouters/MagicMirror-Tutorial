using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class TrafficService : MappableService<TrafficEntity, TrafficModel>, ITrafficService
    {
        private readonly ITrafficRepo _repo;

        public TrafficService()
        {
            _repo = new TrafficRepo();
        }

        public async Task<TrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            TrafficEntity entity = await _repo.GetTrafficInfoAsync(origin, destination);
            TrafficModel model = MapFromEntity(entity);
            model.ConvertValues();

            return model;
        }
    }
}