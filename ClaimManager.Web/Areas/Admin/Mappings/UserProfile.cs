using ClaimManager.Infrastructure.Identity.Models;
using ClaimManager.Web.Areas.Admin.Models;
using AutoMapper;

namespace ClaimManager.Web.Areas.Admin.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}