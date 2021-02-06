using ClaimManager.Domain.Entities.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimManager.Application.Interfaces.Repositories.Claims
{
    public interface ICurrencyRepository
    {
        IQueryable<Currency> Currencies { get; }

        Task<List<Currency>> GetListAsync();

        Task<Currency> GetByIdAsync(int currencyId);

        Task<int> InsertAsync(Currency currency);

        Task UpdateAsync(Currency currency);

        Task DeleteAsync(Currency currency);
    }
}
