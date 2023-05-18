using AutoMapper;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Dto.Product;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesSistemas.SnackNow.Api.Controllers
{
    [Route("products")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ICrudProductService _crudProductService;
        private readonly IMapper _mapper;

        public ProductController(ICrudProductService crudProductService,
            IMapper mapper)
        {
            _crudProductService = crudProductService;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint responsável por adicionar um novo produto.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<HttpDefaultResponse<long>>> AddAsync([FromBody] ProductAddRequest request)
        {
            var result = await _crudProductService.AddAsync(request);
            var response = new HttpDefaultResponse<long>(result);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Endpoint responsável por retornar uma lista de produtos, conforme filtros.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PaginationResponseBase<ProductItemResponse>>> GetAllAsync(
            [FromQuery] QueryPaginationRequest pagination,
            [FromQuery] QueryFilterBase filter)
        {
            var response = await _crudProductService.GetAllAsync(pagination, filter);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint responsável por retornar um produto pelo identificador único.
        /// </summary>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<ProductItemResponse>> GetByIdAsync([FromRoute] long id)
        {
            var result = await _crudProductService.GetByIdAsync(id);
            var response = _mapper.Map<ProductItemResponse>(result);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint responsável por modificar um produto.
        /// </summary>
        [HttpPut("{id:long}")]
        public async Task<NoContentResult> UpdateAsync([FromRoute] long id, [FromBody] ProductAddRequest request)
        {
            await _crudProductService.UpdateAsync(request, id);
            return NoContent();
        }

        /// <summary>
        /// Endpoint responsável por remover um produto.
        /// </summary>
        [HttpDelete("{id:long}")]
        public async Task<NoContentResult> DeleteAsync([FromRoute] long id)
        {
            await _crudProductService.DeleteAsync(id);
            return NoContent();
        }
    }
}