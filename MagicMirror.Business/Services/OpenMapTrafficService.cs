using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class OpenMapTrafficService : MappableService<OpenMapTrafficEntity, TrafficModel>, ITrafficService
    {
        private readonly ITrafficRepo<OpenMapTrafficEntity> _repo;

        public OpenMapTrafficService(IOpenMapTrafficRepo repo, IMapper mapper)
        {
            _repo = repo;
            Mapper = mapper;
        }

        public async Task<TrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            OpenMapTrafficEntity entity = await _repo.GetTrafficInfoAsync(origin, destination);
            TrafficModel model = MapFromEntity(entity);

            model.Origin = origin;
            model.Destination = destination;
            model.InitializeModel();

            return model;
        }
    }
}