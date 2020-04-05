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
            var result = await _planetService.Update(model);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }
    }
}