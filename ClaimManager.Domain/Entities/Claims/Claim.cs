using AspNetCoreHero.Abstractions.Domain;
using System;
using System.Collections.Generic;

namespace ClaimManager.Domain.Entities.Claims
{
    public class Claim : AuditableEntity
    {
        public string Title { get; set; }
        public int Requester { get; set; }
        public int Approver { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ClaimStatus Status { get; set; } = ClaimStatus.Submitted;
        public string RequesterComments { get; set; }
        public string ApproverComments { get; set; }
        public string FinanceComments { get; set; }
        public ICollection<ClaimItem> ClaimItems { get; set; }

    }
}
