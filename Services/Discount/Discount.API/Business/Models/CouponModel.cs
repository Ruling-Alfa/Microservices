namespace Discount.API.Business.Entities
{
    public record CouponModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Amount { get; set; }
    }
}
