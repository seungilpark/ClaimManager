using ClaimManager.Domain.Entities.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManager.Application.Interfaces.Repositories.Claims
{
    public interface IClaimItemRepository
    {
        IQueryable<ClaimItem> ClaimItems { get; }

        Task<List<ClaimItem>> GetListAsync();

        Task<ClaimItem> GetByIdAsync(int itemId);

        Task<int> InsertAsync(ClaimItem claimItem);

        Task UpdateAsync(ClaimItem claimItem);

        Task DeleteAsync(ClaimItem claimItem);
    }
}
