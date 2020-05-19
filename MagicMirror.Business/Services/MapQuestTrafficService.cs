using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class MapQuestTrafficService : MappableService<MapQuestTrafficEntity, TrafficModel>, ITrafficService
    {
        private readonly IMapQuestTrafficRepo _repo;

        public MapQuestTrafficService(IMapQuestTrafficRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            MapQuestTrafficEntity entity = await _repo.GetTrafficInfoAsync(origin, destination);
            TrafficModel model = MapFromEntity(entity);

            model.InitializeModel();
            model.Origin = origin;
            model.Destination = destination;

            return model;
        }
    }
}