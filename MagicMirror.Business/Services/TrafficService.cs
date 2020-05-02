using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class TrafficService : MappableService<GoogleMapsTrafficEntity, GoogleMapsTrafficModel>, ITrafficService
    {
        private readonly ITrafficRepo _repo;

        public TrafficService(ITrafficRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GoogleMapsTrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            GoogleMapsTrafficEntity entity = await _repo.GetTrafficInfoAsync(origin, destination);
            GoogleMapsTrafficModel model = MapFromEntity(entity);
            model.InitializeModel();

            return model;
        }
    }
}