using ClaimManager.Application.Features.Brands.Commands.Create;
using ClaimManager.Application.Features.Brands.Queries.GetAllCached;
using ClaimManager.Application.Features.Brands.Queries.GetById;
using ClaimManager.Domain.Entities.Catalog;
using AutoMapper;

namespace ClaimManager.Application.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsCachedResponse, Brand>().ReverseMap();
        }
    }
}