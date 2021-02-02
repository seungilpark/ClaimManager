using AspNetCoreHero.Abstractions.Domain;
using System;

namespace ClaimManager.Domain.Entities.Claims
{
    public class ClaimItem : BaseEntity
    {
        public string Payee { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal USDAmount { get; set; }
        public string Image { get; set; }
        public int ClaimId { get; set; }
        public Claim Claim { get; set; }
        public int CategoryId { get; set; }
        public ClaimCategory ClaimCategory { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
