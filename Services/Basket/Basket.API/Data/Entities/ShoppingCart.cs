namespace Basket.API.Data.Entities
{
    public record ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
