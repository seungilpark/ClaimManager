using AutoMapper;
using ClaimManager.Application.Features.Claims.Commands.Create;
using ClaimManager.Application.Features.Claims.Queries.Dtos;
using ClaimManager.Domain.Entities.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManager.Application.Mappings
{
    internal class ClaimProfile : Profile
    {
        public ClaimProfile()
        {
            CreateMap<CreateClaimCommand, Claim>().ReverseMap();
            //CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            //CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}
