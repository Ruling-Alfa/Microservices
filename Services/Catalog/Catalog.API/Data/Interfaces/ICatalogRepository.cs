using Catalog.API.Data.Entities;
using CrossCutting.Persistance.Mongo.Interfaces;

namespace Catalog.API.Data.Interfaces
{
    public interface ICatalogRepository
    {
        public IMongoRepository<Product> Products { get; }
    }
}