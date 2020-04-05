using Abac.Web.Api.Core.DTO;
using Abac.Web.Api.Infrastructure.Entities;
using Abac.Web.Api.Infrastructure.Repository;
using AutoMapper;
using System.Threading.Tasks;

namespace Abac.Web.Api.Core.BLLService
{
    public class PlanetService : IPlanetService
    {
        private readonly IAbacRepository<Planet> _planetRepository;
        private readonly IMapper _mapper;
        public PlanetService(IAbacRepository<Planet> planetRepository, IMapper mapper)
        {
            _planetRepository = planetRepository;
            _mapper = mapper;
        }

        public async Task<PlanetDTO> Update(PlanetDTO model)
        {
            var modelDb = _mapper.Map<PlanetDTO,Planet>(model);
            var result = await _planetRepository.Update(modelDb,modelDb.Id);
            return _mapper.Map<PlanetDTO>(result);
        }
    }
}
