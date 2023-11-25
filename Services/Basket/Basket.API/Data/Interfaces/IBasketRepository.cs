using Basket.API.Data.Entities;

namespace Basket.API.Data.Interfaces
{
    public interface IBasketRepository
    {
        Task<bool> DeleteBasket(string UserName);
        Task<ShoppingCart> GetBasket(string UserName);
        Task<bool> SetBasket(string UserName, ShoppingCart basket);
        Task<bool> UpdateBasket(string UserName, ShoppingCart basket);
    }
}