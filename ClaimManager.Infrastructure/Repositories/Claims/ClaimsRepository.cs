using ClaimManager.Application.Interfaces.Repositories;
using ClaimManager.Application.Interfaces.Repositories.Claims;
using ClaimManager.Domain.Entities.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManager.Infrastructure.Repositories.Claims
{
    public class ClaimsRepository : IClaimsRepository
    {
        private readonly IRepositoryAsync<Claim> _repository;
        private readonly IDistributedCache _distributedCache;
        public ClaimsRepository(IDistributedCache distributedCache, IRepositoryAsync<Claim> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<Claim> Claims => _repository.Entities;


        public async Task DeleteAsync(Claim claim)
        {
            await _repository.DeleteAsync(claim);
            await _distributedCache.RemoveAsync(CacheKeys.ClaimCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ClaimCacheKeys.GetKey(claim.Id));
        }

        public async Task<Claim> GetByIdAsync(int claimId)
        {
            var claim = await Claims
                .Where(c => c.Id == claimId)
                .Include(c => c.ClaimItems)
                    .ThenInclude(ci => ci.Currency)
                .Include(c => c.ClaimItems)
                    .ThenInclude(ci => ci.ClaimCategory)
                .FirstOrDefaultAsync();

            return claim;
        }

        public async Task<List<Claim>> GetListAsync()
        {
            return await Claims.Include(c => c.ClaimItems).AsNoTracking().ToListAsync();
        }

        public async Task<int> InsertAsync(Claim claim)
        {
            await _repository.AddAsync(claim);
            await _distributedCache.RemoveAsync(CacheKeys.ClaimCacheKeys.ListKey);
            return claim.Id;
        }
        public Task Approve(int claimId)
        {
            throw new NotImplementedException();
        }

        public Task Query(int claimId)
        {
            throw new NotImplementedException();
        }

        public Task Reject(int claimId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Claim claim)
        {
            await _repository.UpdateAsync(claim);
            await _distributedCache.RemoveAsync(CacheKeys.ClaimCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ClaimCacheKeys.GetKey(claim.Id));
        }
    }
}
