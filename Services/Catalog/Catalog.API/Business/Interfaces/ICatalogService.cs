using Catalog.API.Business.Models;

namespace Catalog.API.Business.Interfaces
{
    public interface ICatalogService
    {
        Task<ProductModel> AddProduct(ProductModel productModel);
        Task<ProductModel> GetProduct(string id);
        Task<IEnumerable<ProductModel>> GetProductByCategory(string category);
        IEnumerable<ProductModel> GetProducts();
        Task RemoveProduct(string productId);
        Task<ProductModel> UpdateProduct(ProductModel productModel);
    }
}