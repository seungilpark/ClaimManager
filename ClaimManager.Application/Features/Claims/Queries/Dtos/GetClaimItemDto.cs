using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManager.Application.Features.Claims.Queries.Dtos
{
    public class GetClaimItemDto
    {
        public string Payee { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal USDAmount { get; set; }
        public string Image { get; set; }
        public string CurrencySymbol { get; set; }
        public string CategoryCode { get; set; }
    }
}
