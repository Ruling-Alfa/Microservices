using Basket.API.Business.Models;


namespace Basket.API.Data.Interfaces
{
    public interface IBasketService
    {
        Task<bool> DeleteBasket(string UserName);
        Task<ShoppingCartModel> GetBasket(string UserName);
        Task<bool> SetBasket(string UserName, ShoppingCartModel basket);
        Task<bool> UpdateBasket(string UserName, ShoppingCartModel basket);
    }
}