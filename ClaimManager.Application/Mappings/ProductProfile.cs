using ClaimManager.Application.Features.Products.Commands.Create;
using ClaimManager.Application.Features.Products.Queries.GetAllCached;
using ClaimManager.Application.Features.Products.Queries.GetAllPaged;
using ClaimManager.Application.Features.Products.Queries.GetById;
using ClaimManager.Domain.Entities.Catalog;
using AutoMapper;

namespace ClaimManager.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}