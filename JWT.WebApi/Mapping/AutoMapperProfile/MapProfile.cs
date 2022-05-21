using AutoMapper;
using JWT.Entities.Concrete;
using JWT.Entities.Dtos.ProductDtos;

namespace JWT.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductAddDto>();
            CreateMap<ProductAddDto, Product>();

            CreateMap<Product, ProductUpdateDto>();
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
