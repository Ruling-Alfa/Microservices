using AutoMapper;
using Catalog.API.Business.Interfaces;
using Catalog.API.Business.Models;
using Catalog.API.Data.Entities;
using Catalog.API.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Business
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapper _mapper;
        public CatalogService(ICatalogRepository catalogRepository, IMapper mapper)
        {
            _catalogRepository = catalogRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            var products =  _catalogRepository.Products.FilterBy(_ => true).ToList();
            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public async Task<ProductModel> GetProduct(string id)
        {
            var product = await _catalogRepository.Products.FindByIdAsync(id).ConfigureAwait(false);
            return _mapper.Map<ProductModel>(product);
        }

        public async Task<IEnumerable<ProductModel>> GetProductByCategory(string category)
        {
            var products = await _catalogRepository.Products.AsQueryable()
                .Where(p => p.Category == category).ToListAsync();
            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public async Task<ProductModel> AddProduct(ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);
            await _catalogRepository.Products.InsertOneAsync(product);
            return _mapper.Map<ProductModel>(product);
        }

        public async Task RemoveProduct(string productId)
        {
            await _catalogRepository.Products.DeleteOneAsync(p => p.Id == (object)productId);
        }

        public async Task<ProductModel> UpdateProduct(ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);
            await _catalogRepository.Products.ReplaceOneAsync(product);
            return _mapper.Map<ProductModel>(product);
        }
    }
}
