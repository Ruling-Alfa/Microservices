﻿namespace Basket.API.Data.Entities
{
    public record ShoppingCartItem
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal  Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
