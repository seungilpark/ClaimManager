using AspNetCoreHero.Abstractions.Domain;

namespace ClaimManager.Domain.Entities.Claims
{
    public class ClaimCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ClaimItem ClaimItem { get; set; }
    }
}
