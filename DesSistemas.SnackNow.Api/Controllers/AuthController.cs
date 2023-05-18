using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Dto.UserSystem;
using DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto;
using DesSistemas.SnackNow.RecaptchaHelper;
using Microsoft.AspNetCore.Mvc;

namespace DesSistemas.SnackNow.Api.Controllers
{
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ICrudUserSystemService _userSystemService;

        public AuthController(IAuthService authService,
            ICrudUserSystemService userSystemService)
        {
            _authService = authService;
            _userSystemService = userSystemService;
        }

        [ValidateReCaptcha]
        [HttpPost("login")]
        public async Task<ActionResult<AuthZeroLoginResponse>> LoginAsync([FromBody] AuthZeroLoginRequest login)
        {
            var response = await _authService.LoginAsync(login);
            return Ok(response);
        }

        [HttpPost("sign")]
        public async Task<ActionResult> SignAsync([FromBody] UserSystemAddRequest request)
        {
            await _userSystemService.AddAsync(request);
            return Ok();
        }
    }
}