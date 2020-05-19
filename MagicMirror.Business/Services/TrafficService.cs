using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class TrafficService : MappableService<GoogleMapsTrafficEntity, TrafficModel>, ITrafficService
    {
        private readonly IGoogleMapsTrafficRepo _repo;

        public TrafficService(IGoogleMapsTrafficRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            GoogleMapsTrafficEntity entity = await _repo.GetTrafficInfoAsync(origin, destination);
            TrafficModel model = MapFromEntity(entity);
            model.InitializeModel();

            return model;
        }
    }
}