using CrossCutting.Persistance.SQL.Entities;

namespace Discount.Grpc.Data.Entities
{
    public record Coupon : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Amount { get; set; }
    }
}
