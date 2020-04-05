using Abac.Web.Api.Core.DTO;
using System.Threading.Tasks;

namespace Abac.Web.Api.Core.BLLService
{
    public interface IPlanetService
    {
        public Task<PlanetDTO> Update(PlanetDTO model);
    }
}
