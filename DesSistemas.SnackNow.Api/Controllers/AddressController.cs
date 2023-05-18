using AutoMapper;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Dto.Address;
using DesSistemas.SnackNow.RecaptchaHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesSistemas.SnackNow.Api.Controllers
{
    [Route("address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressSearchService _addressService;
        private readonly IMapper _mapper;
        private readonly IGeocodingHelper _geocodingHelper;

        public AddressController(IAddressSearchService addressService,
            IMapper mapper,
            IGeocodingHelper geocodingHelper)
        {
            _addressService = addressService;
            _mapper = mapper;
            _geocodingHelper = geocodingHelper;
        }

        /// <summary>
        /// Endpoint responsável por consultar endereços pelo código postal.
        /// </summary>
        [HttpGet("{postalCode}")]
        [ProducesResponseType(typeof(AddressItemResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<AddressItemResponse>> GetByPostalCodeAsync([FromRoute] string postalCode)
        {
            var address = await _addressService.GetByPostalCodeAsync(postalCode);
            var result = _mapper.Map<AddressItemResponse>(address);
            return Ok(result);
        }

        [HttpGet("geocoding")]
        public async Task<ActionResult> GetByLatituteAndLongitude([FromQuery]string latitude, [FromQuery]string longitude)
        {
            var result = await _geocodingHelper.GetAddressAsync(latitude, longitude);
            return Ok(new { data = result });
        }
    }
}