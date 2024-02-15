using Asp.Versioning;
using AutoMapper;
using Basket.API.Business.Models;
using Basket.API.Data.Interfaces;
using Basket.API.GrpcServices;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

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


        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout, [FromServices] IMapper mapper,
            [FromServices]IPublishEndpoint publishEndpoint)
        {
            if (basketCheckout is null || string.IsNullOrEmpty(basketCheckout.UserName))
            {
                return BadRequest();
            }
            var basket = await _basketService.GetBasket(basketCheckout.UserName);
            if (basket is null)
            {
                return NotFound();
            }

            var eventMsg = mapper.Map<BasketCheckoutEvent>(basketCheckout);
            eventMsg.TotalPrice = basket.TotalPrice;
            //eventMsg.TotalPrice = basket.TotalPrice;
            await publishEndpoint.Publish(eventMsg);

            await _basketService.DeleteBasket(basketCheckout.UserName);
            return Accepted();
        }
    }
}
