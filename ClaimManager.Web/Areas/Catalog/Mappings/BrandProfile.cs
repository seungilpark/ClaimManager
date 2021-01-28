using ClaimManager.Application.Features.Brands.Commands.Create;
using ClaimManager.Application.Features.Brands.Commands.Update;
using ClaimManager.Application.Features.Brands.Queries.GetAllCached;
using ClaimManager.Application.Features.Brands.Queries.GetById;
using ClaimManager.Web.Areas.Catalog.Models;
using AutoMapper;

namespace ClaimManager.Web.Areas.Catalog.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<GetAllBrandsCachedResponse, BrandViewModel>().ReverseMap();
            CreateMap<GetBrandByIdResponse, BrandViewModel>().ReverseMap();
            CreateMap<CreateBrandCommand, BrandViewModel>().ReverseMap();
            CreateMap<UpdateBrandCommand, BrandViewModel>().ReverseMap();
        }
    }
}