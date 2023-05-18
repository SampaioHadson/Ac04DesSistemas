using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Dto.UserSystemPassRecovery;
using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using Microsoft.AspNetCore.Mvc;

namespace DesSistemas.SnackNow.Api.Controllers
{
    [Route("pass-recovery")]
    public class UserSystemPassRecoveryController : ControllerBase
    {
        private readonly IPassRecoveryService _passRecoveryService;

        public UserSystemPassRecoveryController(IPassRecoveryService passRecoveryService)
        {
            _passRecoveryService = passRecoveryService;
        }

        [HttpPost("send-sms")]
        public async Task<ActionResult> SendSmsAsync([FromBody] SendSmsRequest request)
        {
            await _passRecoveryService.SendSmsToRecoveryAsync(request.Email);
            return NoContent();
        }

        [HttpPost("confirm-sms")]
        public async Task<ActionResult<HttpDefaultResponse<string>>> ConfirmSmsAsync([FromBody] ConfirmSmsRequest request)
        {
            var result = await _passRecoveryService.ConfirmSmsAsync(request);
            var response = new HttpDefaultResponse<string>(result);
            return Ok(response);
        }

        [HttpPost("change-password")]
        public async Task<ActionResult> ChangePasswordAsync([FromBody] ChangePasswordRequest request)
        {
            await _passRecoveryService.ChangePasswordAsync(request);
            return NoContent();
        }
    }
}