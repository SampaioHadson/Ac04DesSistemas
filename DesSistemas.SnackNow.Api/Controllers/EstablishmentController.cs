using AutoMapper;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Dto.Establishments;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesSistemas.SnackNow.Api.Controllers
{
    [Route("establishments")]
    [Authorize]
    public class EstablishmentController : ControllerBase
    {
        private readonly ICrudEstablishmentService _establishmentService;
        private readonly IMapper _mapper;

        public EstablishmentController(ICrudEstablishmentService establishmentService,
            IMapper mapper)
        {
            _establishmentService = establishmentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint responsável por adicionar um novo estabelecimento.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<HttpDefaultResponse<long>>> AddAsync([FromBody] EstablishmentAddRequest request)
        {
            var result = await _establishmentService.AddAsync(request);
            var response = new HttpDefaultResponse<long>(result);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Endpoint responsável por retornar uma lista de estabelecimentos, conforme filtros.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PaginationResponseBase<EstablishmentItemResponse>>> GetAllAsync(
            [FromQuery] QueryPaginationRequest pagination,
            [FromQuery] QueryFilterBase filter)
        {
            var response = await _establishmentService.GetAllAsync(pagination, filter);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint responsável por retornar um estabelecimento pelo identificador único.
        /// </summary>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<EstablishmentItemResponse>> GetByIdAsync([FromRoute] long id)
        {
            var result = await _establishmentService.GetByIdAsync(id);
            var response = _mapper.Map<EstablishmentItemResponse>(result);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint responsável por modificar um estabelecimento.
        /// </summary>
        [HttpPut("{id:long}")]
        public async Task<NoContentResult> UpdateAsync([FromRoute] long id, [FromBody] EstablishmentAddRequest request)
        {
            await _establishmentService.UpdateAsync(request, id);
            return NoContent();
        }

        /// <summary>
        /// Endpoint responsável por remover um estabelecimento.
        /// </summary>
        [HttpDelete("{id:long}")]
        public async Task<NoContentResult> DeleteAsync([FromRoute] long id)
        {
            await _establishmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}