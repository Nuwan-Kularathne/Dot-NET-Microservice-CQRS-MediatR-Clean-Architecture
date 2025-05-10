using Microsoft.EntityFrameworkCore;
using TyreManagement.Core.Domain.Entities;
using TyreManagement.Core.Domain.Entities.Common;

namespace TyreManagement.Persistence.DatabaseContext

{
  public class TyresDatabaseContext : DbContext
  {
    public TyresDatabaseContext(DbContextOptions<TyresDatabaseContext> options) : base(options)
    {

    }
    public DbSet<TyreProduct> TyreProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(TyresDatabaseContext).Assembly);
      base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
          .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
      {
        entry.Entity.DateModified = DateTime.Now;

        if (entry.State == EntityState.Added)
        {
          entry.Entity.DateCreated = DateTime.Now;
        }
      }

      return base.SaveChangesAsync(cancellationToken);
    }
  }
}
