using ClaimManager.Application.Features.Products.Commands.Create;
using ClaimManager.Application.Features.Products.Commands.Update;
using ClaimManager.Application.Features.Products.Queries.GetAllCached;
using ClaimManager.Application.Features.Products.Queries.GetById;
using ClaimManager.Web.Areas.Catalog.Models;
using AutoMapper;

namespace ClaimManager.Web.Areas.Catalog.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetAllProductsCachedResponse, ProductViewModel>().ReverseMap();
            CreateMap<GetProductByIdResponse, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}