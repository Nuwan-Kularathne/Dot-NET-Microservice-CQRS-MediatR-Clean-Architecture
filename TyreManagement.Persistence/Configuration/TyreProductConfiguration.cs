using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TyreManagement.Core.Domain.Entities;

namespace TyreManagement.Persistence.Configuration;

public class TyreProductConfiguration : IEntityTypeConfiguration<TyreProduct>
{
  public void Configure(EntityTypeBuilder<TyreProduct> builder)
  {
    builder.HasData(
        new TyreProduct
        {
          Id = 1,
          Name = "Michelin Pilot Sport",
          UnitPrice = 100,
          QuantityInStock = 5000,
          DateCreated = new DateTime(2025, 5, 3),
          DateModified = new DateTime(2025, 5, 3)
        },
        new TyreProduct
        {
          Id = 2,
          Name = "Kumho E31",
          UnitPrice = 200,
          QuantityInStock = 10000,
          DateCreated = new DateTime(2025, 5, 3),
          DateModified = new DateTime(2025, 5, 3)
        },
        new TyreProduct
        {
          Id = 3,
          Name = "Bridgestone Turanza Serenity",
          UnitPrice = 300,
          QuantityInStock = 15000,
          DateCreated = new DateTime(2025, 5, 3),
          DateModified = new DateTime(2025, 5, 3)
        }
    );

    builder.Property(q => q.Name)
        .IsRequired()
        .HasMaxLength(100);
  }
}