using Abac.Web.Api.Core.BLLService;
using Abac.Web.Api.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Abac.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private IPlanetService _planetService;

        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PlanetDTO model)
        {
            if (await _planetService.Update(model)!=null)
                return Ok();
            else
                return NotFound();
        }
    }
}