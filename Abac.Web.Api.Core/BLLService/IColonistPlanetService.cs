using Abac.Web.Api.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abac.Web.Api.Core.BLLService
{
    public interface IColonistPlanetService
    {
        public Task<List<ColonistPlanetDTO>> GetAll();
    }
}
