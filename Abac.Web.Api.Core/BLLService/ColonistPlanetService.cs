using Abac.Web.Api.Core.BLLService;
using Abac.Web.Api.Core.DTO;
using Abac.Web.Api.Infrastructure.Entities;
using Abac.Web.Api.Infrastructure.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abac.Web.Api.Core.Service
{
    public class ColonistPlanetService : IColonistPlanetService
    {   
        private readonly IAbacRepository<Planet> _planetRepository;
        private readonly IMapper _mapper;

        public ColonistPlanetService(IAbacRepository<Planet> planetRepository,IMapper mapper)
        {
            _planetRepository = planetRepository;
            _mapper = mapper;
        }

        public async Task<List<ColonistPlanetDTO>> GetAll()
        {
            var result = await _planetRepository.GetAll().Include(planet => planet.ColonistPlanet)
                                                .ThenInclude(colonistPlanet => colonistPlanet.Colonist)
                                                .ToListAsync();
            return _mapper.Map<List<ColonistPlanetDTO>>(result);
        }
    }
}
