using AspNetCoreHero.Abstractions.Domain;

namespace ClaimManager.Domain.Entities.Claims
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public ClaimItem ClaimItem { get; set; }
    }
}
