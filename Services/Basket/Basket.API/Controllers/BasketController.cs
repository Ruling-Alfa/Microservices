using Basket.API.Business.Models;
using Basket.API.Data.Interfaces;
using Basket.API.GrpcServices;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly DiscountGrpcService _discountGrpcService;
        public BasketController(IBasketService basketService, DiscountGrpcService discountGrpcService)
        {
            _basketService = basketService;
            _discountGrpcService = discountGrpcService;
        }

        [HttpGet]
        [Route("{UserName}")]
        public async Task<IActionResult> Basket([FromRoute] string UserName)
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return BadRequest();
            }
            var basket = await _basketService.GetBasket(UserName);
            if (basket is null)
            {
                return NotFound();
            }
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ShoppingCartModel basket)
        {
            if (basket is null || !basket.ShoppingCartItems.Any() || string.IsNullOrEmpty(basket.UserName))
            {
                return BadRequest();
            }
            foreach(var basketItem in basket.ShoppingCartItems)
            {
                var coupoun = await _discountGrpcService.GetDiscount(basketItem.ProductName);
                basketItem.Price -= coupoun.Amount;
            }
            var isSuccess = await _basketService.SetBasket(basket.UserName, basket);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Basket), new { UserName = basket.UserName }, basket);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ShoppingCartModel basket)
        {
            if (basket is null || !basket.ShoppingCartItems.Any() || string.IsNullOrEmpty(basket.UserName))
            {
                return BadRequest();
            }
            var isSuccess = await _basketService.UpdateBasket(basket.UserName, basket);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{UserName}")]
        public async Task<IActionResult> Remove([FromRoute] string UserName)
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return BadRequest();
            }
            var isSuccess = await _basketService.DeleteBasket(UserName);
            if (!isSuccess)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
