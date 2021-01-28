using ClaimManager.Domain.Entities.Catalog;
using ClaimManager.Domain.Entities.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ClaimManager.Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        IDbConnection Connection { get; }
        bool HasChanges { get; }

        EntityEntry Entry(object entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<Product> Products { get; set; }
        DbSet<Claim> Claims { get; set; }
        DbSet<ClaimItem> ClaimItems { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<ClaimCategory> ClaimCategories { get; set; }
    }
}