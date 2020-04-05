using System.Threading.Tasks;
using Abac.Web.Api.Core.BLLService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Abac.Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,User")]
    [ApiController]
    public class ColonistPlanetController : ControllerBase
    {
        private IColonistPlanetService _colonistPlanetService;

        public ColonistPlanetController(IColonistPlanetService colonistPlanetService)
        {
            _colonistPlanetService = colonistPlanetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _colonistPlanetService.GetAll());
        }
    }
}