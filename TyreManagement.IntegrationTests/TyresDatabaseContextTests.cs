
using Microsoft.EntityFrameworkCore;
using Shouldly;
using TyreManagement.Persistence.DatabaseContext;
using TyreManagement.Core.Domain.Entities;

namespace TyreManagement.IntegrationTests
{
  public class TyresDatabaseContextTests
  {
    private TyresDatabaseContext _tyresDatabaseContext;

    public TyresDatabaseContextTests()
    {
      var dbOptions = new DbContextOptionsBuilder<TyresDatabaseContext>()
          .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

      _tyresDatabaseContext = new TyresDatabaseContext(dbOptions);
    }

    [Fact]
    public async void Save_SetDateCreatedValue()
    {
      // Arrange
      var tyreProduct = new TyreProduct
      {
        Name = "Test Tyre Product 01",
        UnitPrice = 100,
        QuantityInStock = 5000,
      };

      // Act
      await _tyresDatabaseContext.TyreProducts.AddAsync(tyreProduct);
      await _tyresDatabaseContext.SaveChangesAsync();

      // Assert
      tyreProduct.DateCreated.ShouldNotBe(default);
    }

    [Fact]
    public async void Save_SetDateModifiedValue()
    {
      // Arrange
      var tyreProduct = new TyreProduct
      {
        Name = "Test Tyre Product 02",
        UnitPrice = 100,
        QuantityInStock = 5000,
      };

      // Act
      await _tyresDatabaseContext.TyreProducts.AddAsync(tyreProduct);
      await _tyresDatabaseContext.SaveChangesAsync();

      // Assert
      tyreProduct.DateModified.ShouldNotBe(default);
    }
  }
}