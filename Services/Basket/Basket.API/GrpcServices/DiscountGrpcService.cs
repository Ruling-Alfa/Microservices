using Amazon.Runtime.Internal;
using Discount.Grpc.Protos;
using Grpc.Core;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;
        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService;
        }

        public async Task<CouponModel> GetDiscount(string ProductName)
        {
            if (string.IsNullOrEmpty(ProductName))
            {
                return new CouponModel() { Amount = 0, ProductName = "Empty", ProductDescription = "ProductName is Empty" };
            }
            return await _discountProtoService.GetDiscountAsync(new GetDiscountRequest { ProductName = ProductName });
        }
    }
}
