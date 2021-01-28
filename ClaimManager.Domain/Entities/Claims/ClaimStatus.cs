using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManager.Domain.Entities.Claims
{
    public enum ClaimStatus
    {
        Submitted,
        Rejected,
        Queryed,
        Approved,
        Processed
    }
}
