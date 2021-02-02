using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManager.Infrastructure.CacheKeys
{
    public static class ClaimCacheKeys
    {
        public static string ListKey => "ClaimsList";

        public static string SelectListKey => "ClaimsSelectList";

        public static string GetKey(int claimId) => $"Claim-{claimId}";

        public static string GetDetailsKey(int claimId) => $"ClaimDetails-{claimId}";
    }
}
