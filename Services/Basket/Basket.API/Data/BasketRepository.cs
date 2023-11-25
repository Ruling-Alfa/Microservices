using AutoMapper;
using Basket.API.Data.Entities;
using Basket.API.Data.Interfaces;
using CrossCutting.Persistance.Redis.Interfaces;

namespace Basket.API.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ICacheService _cacheService;
        public BasketRepository(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<ShoppingCart> GetBasket(string UserName)
        {
            var basket = await _cacheService.GetData<ShoppingCart>(UserName);
            return basket;
        }

        public async Task<bool> SetBasket(string UserName, ShoppingCart basket)
        {
            return await _cacheService.SetData(UserName, basket);
        }

        public async Task<bool> UpdateBasket(string UserName, ShoppingCart basket)
        {
            return await _cacheService.SetData(UserName, basket);
        }

        public async Task<bool> DeleteBasket(string UserName)
        {
            return await _cacheService.RemoveData(UserName);
        }
    }
}
