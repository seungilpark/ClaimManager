using ClaimManager.Domain.Entities.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManager.Application.Interfaces.Repositories.Claims
{
    public interface IClaimCategoryRepository
    {
        IQueryable<ClaimCategory> Categories { get; }

        Task<List<ClaimCategory>> GetListAsync();

        Task<ClaimCategory> GetByIdAsync(int categoryId);

        Task<int> InsertAsync(ClaimCategory category);

        Task UpdateAsync(ClaimCategory category);

        Task DeleteAsync(ClaimCategory category);
    }
}
