using AutoMapper;
using Catalog.API.Business.Models;
using Catalog.API.Data.Entities;

namespace Catalog.API.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
               CreateMap<ProductModel, Product>().ReverseMap();
        }
    }
}
