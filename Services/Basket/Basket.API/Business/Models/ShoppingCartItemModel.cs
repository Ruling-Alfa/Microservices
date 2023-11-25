namespace Basket.API.Business.Models
{
    public record ShoppingCartItemModel
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal  Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
