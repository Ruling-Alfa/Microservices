using Asp.Versioning;
using Catalog.API.Business.Interfaces;
using Catalog.API.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        public IActionResult Products()
        {
            var allProducts = _catalogService.GetProducts();
            if (allProducts is null || !allProducts.Any())
            {
                return NotFound();
            }
            return Ok(allProducts);
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> Product([FromRoute] string productId)
        {
            var product = await _catalogService.GetProduct(productId);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductModel product)
        {
            if (product is null)
            {
                return BadRequest();
            }
            var productModel = await _catalogService.AddProduct(product);
            if (productModel is null || string.IsNullOrEmpty(productModel.Id))
            {
                return NoContent();
            }
            return CreatedAtAction(nameof(Product), new { productId = productModel.Id }, productModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductModel product)
        {
            if (product is null)
            {
                return BadRequest();
            }
            var productModel = await _catalogService.UpdateProduct(product);

            return NoContent();
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> Remove([FromRoute] string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return BadRequest();
            }
            await _catalogService.RemoveProduct(productId);

            return NoContent();
        }
    }
}
