using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class TrafficService : MappableService<OpenMapTrafficEntity, TrafficModel>, ITrafficService
    {
        private readonly ITrafficRepo<OpenMapTrafficEntity> _repo;

        public TrafficService(ITrafficRepo<OpenMapTrafficEntity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            var entity = await _repo.GetTrafficInfoAsync(origin, destination);
            var model = MapFromEntity(entity);
            model.InitializeModel();

            return model;
        }
    }
}