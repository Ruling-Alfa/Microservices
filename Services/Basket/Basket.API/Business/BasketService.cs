using AutoMapper;
using Basket.API.Business.Models;
using Basket.API.Data.Entities;
using Basket.API.Data.Interfaces;

namespace Basket.API.Business
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketService(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public Task<bool> DeleteBasket(string UserName)
        {
            return _basketRepository.DeleteBasket(UserName);
        }

        public async Task<ShoppingCartModel> GetBasket(string UserName)
        {
            var basket = await _basketRepository.GetBasket(UserName);
            return _mapper.Map<ShoppingCartModel>(basket);
        }

        public Task<bool> SetBasket(string UserName, ShoppingCartModel basketModel)
        {
            var basket = _mapper.Map<ShoppingCart>(basketModel);
            return _basketRepository.SetBasket(UserName, basket);
        }

        public Task<bool> UpdateBasket(string UserName, ShoppingCartModel basketModel)
        {
            var basket = _mapper.Map<ShoppingCart>(basketModel);
            return _basketRepository.UpdateBasket(UserName, basket);
        }
    }
}
