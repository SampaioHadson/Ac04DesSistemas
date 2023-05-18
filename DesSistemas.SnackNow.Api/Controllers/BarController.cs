using DesSistemas.SnackNow.Api.Domain.Services;
using DesSistemas.SnackNow.Api.Dto.Bars;
using Microsoft.AspNetCore.Mvc;

namespace DesSistemas.SnackNow.Api.Controllers
{
    [Route("bar")]
    public class BarController : ControllerBase
    {
        private readonly IBarService _barService;

        public BarController(IBarService barService)
        {
            _barService = barService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] BarAddRequest request)
        {
            await _barService.AddAsync(request);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _barService.GetAllAsync();
            return Ok(result);
        }
    }
}
