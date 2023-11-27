using Asp.Versioning;
using Discount.API.Business.Entities;
using Discount.API.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Discount.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }



        [HttpGet]
        [Route("{ProductName}")]
        public async Task<IActionResult> Discount([FromRoute] string ProductName)
        {
            var product = await _discountService.GetDiscount(ProductName);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CouponModel Coupon)
        {
            if (Coupon is null)
            {
                return BadRequest();
            }
            var couponModel = await _discountService.CreateDiscount(Coupon);
            if (couponModel is null || couponModel.Id <= 0)
            {
                return NoContent();
            }
            return CreatedAtAction(nameof(Discount), new { ProductName = couponModel.ProductName }, couponModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CouponModel Coupon)
        {
            if (Coupon is null)
            {
                return BadRequest();
            }
            var couponModel = await _discountService.UpdateDiscount(Coupon);
            if (couponModel is null || couponModel.Id <= 0)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{ProductName}")]
        public async Task<IActionResult> Remove([FromRoute] string ProductName)
        {
            if (string.IsNullOrEmpty(ProductName))
            {
                return BadRequest();
            }
            var isSuccess = await _discountService.DeleteDiscount(ProductName);
            if (!isSuccess)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            return NoContent();
        }
    }
}
