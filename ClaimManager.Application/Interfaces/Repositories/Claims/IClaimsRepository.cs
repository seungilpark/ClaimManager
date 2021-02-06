using ClaimManager.Domain.Entities.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManager.Application.Interfaces.Repositories.Claims
{
    public interface IClaimsRepository
    {
        IQueryable<Claim> Claims { get; }

        Task<List<Claim>> GetListAsync();

        Task<Claim> GetByIdAsync(int claimId);

        Task<int> InsertAsync(Claim claim);

        Task UpdateAsync(Claim claim);

        Task DeleteAsync(Claim claim);
        Task Approve(int claimId);
        Task Query(int claimId);
        Task Reject(int claimId);
    }
}
