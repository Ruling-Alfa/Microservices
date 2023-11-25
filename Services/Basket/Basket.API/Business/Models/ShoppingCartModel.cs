namespace Basket.API.Business.Models
{
    public record ShoppingCartModel
    {
        public string UserName { get; set; }
        public List<ShoppingCartItemModel> ShoppingCartItems { get; set; }
        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (var item in ShoppingCartItems)
                {
                    total += item.Price * item.Quantity;   
                }
                return total;
            }
        }
    }
}
