using Catalog.API.Data.Entities;
using Catalog.API.Data.Interfaces;
using CrossCutting.Persistance.Mongo.Interfaces;

namespace Catalog.API.Data
{
    public class CatalogRepository : ICatalogRepository
    {
        IMongoRepository<Product> _catatlogRepository;
        public CatalogRepository(IMongoRepository<Product> catatlogRepository)
        {
            _catatlogRepository = catatlogRepository;
        }

        public IMongoRepository<Product> Products { get { return _catatlogRepository; } }

    }
}
