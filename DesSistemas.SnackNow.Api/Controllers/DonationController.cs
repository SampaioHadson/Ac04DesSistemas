using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Dto.DonationRequests;
using DesSistemas.SnackNow.Api.Dto.Payment;
using Microsoft.AspNetCore.Mvc;

namespace DesSistemas.SnackNow.Api.Controllers
{
    [Route("donations")]
    public class DonationController : ControllerBase
    {
        private readonly IDonationRequestService _donationRequestService;
        private readonly IPaymentService _paymentService;

        public DonationController(IDonationRequestService donationRequestService, IPaymentService paymentService)
        {
            _donationRequestService = donationRequestService;
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<ActionResult> AddDonationRequest([FromBody] DonationRequestAdd add)
        {
            await _donationRequestService.AddAsync(add);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> ListAll()
        {
            var result = await _donationRequestService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult> GetImageBase64([FromRoute] long id)
        {
            var image = await _donationRequestService.GetImageAsync(id);
            return Ok(image);
        }

        [HttpPost("payment")]
        public async Task<ActionResult> AddPaymentAsync([FromBody] PaymentAddRequest add)
        {
            var result = await _paymentService.GenerateQrCodeAsync(add);
            return Ok(result);
        }

        [HttpPost("payment/validate")]
        public async Task<ActionResult> ValidatePayment([FromBody] ValidatePaymentRequest validate)
        {
            var result = await _paymentService.ValidatePaymentAsync(validate);
            return Ok(result);
        }
    }
}