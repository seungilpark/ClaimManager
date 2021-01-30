using AspNetCoreHero.Abstractions.Domain;
using System.Collections.Generic;

namespace ClaimManager.Domain.Entities.Claims
{
    public class ClaimCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<ClaimItem> ClaimItems { get; set; }
    }
}
