using Ecommerce.Application.IServices;
using ECommerce.Domain.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("GetCombination")]
        public ActionResult<IEnumerable<ProductoConComponentesDTO>> GetCombination()
        {
            var response = _productoService.GetCombination();

            if (!response.Any())
            {
                return NotFound("No se encontraron recursos en la base de datos");
            }

            return Ok(response);
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<ProductoDTO?>> GetAll()
        {
            var response = _productoService.GetProductList();

            if (!response.Any())
            {
                return NotFound("No se encontraron recursos en la base de datos");
            }

            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<ProductoDTO?> GetById([FromRoute] Guid id)
        {
            var producto = _productoService.GetById(id);

            if (producto == null)
            {
                return NotFound("No se encontro el recurso en la base de datos");
            }

            return Ok(producto);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateProductoViewModel producto)
        {
            var created = _productoService.CreateProduct(producto);

            if (!created)
            {
                return BadRequest("Id de producto existente");
            }

            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string apiAndEndpointUrl = $"api/Producto/GetById";
            string locationUrl = $"{baseUrl}/{apiAndEndpointUrl}/{producto.Id}";

            return Created(locationUrl, producto);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CreateProductoViewModel producto)
        {
            var updated = _productoService.UpdateProduct(producto);

            if (!updated)
            {
                return NotFound("No se encontro el recurso en la base de datos");
            }

            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var deleted = _productoService.DeleteProduct(id);

            if (!deleted)
            {
                return NotFound("No se encontro el recurso en la base de datos");
            }

            return NoContent();
        }
    }
}