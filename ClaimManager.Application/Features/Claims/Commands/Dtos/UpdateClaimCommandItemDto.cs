using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManager.Application.Features.Claims.Commands.Dtos
{
    public class UpdateClaimCommandItemDto
    {
        public int Id { get; set; }
        public string Payee { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal USDAmount { get; set; }
        public string Image { get; set; }
        public int ClaimCategoryId { get; set; }
        public int CurrencyId { get; set; }
        public int ClaimId { get; set; }
    }
}
