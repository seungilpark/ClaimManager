using AspNetCoreHero.Abstractions.Domain;
using System.Collections.Generic;

namespace ClaimManager.Domain.Entities.Claims
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public ICollection<ClaimItem> ClaimItems { get; set; }
    }
}
