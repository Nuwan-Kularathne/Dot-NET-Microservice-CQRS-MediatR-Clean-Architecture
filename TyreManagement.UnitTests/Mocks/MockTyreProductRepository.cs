using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyreManagement.Core.Domain.Contracts.RepositoryContracts;
using TyreManagement.Core.Domain.Entities;

namespace TyreManagement.UnitTests.Mocks
{
  public class MockTyreProductRepository
  {
    public static Mock<ITyreProductRepository> GetMockTyreProductRepository()
    {
      var tyreProducts = new List<TyreProduct>
      {
        new TyreProduct
        {
          Id = 1,
          Name = "Test Tyre ABC",
          UnitPrice = 100,
          QuantityInStock = 5000,
          DateCreated = new DateTime(2020, 5, 3),
          DateModified = new DateTime(2020, 5, 3)
        },
        new TyreProduct
        {
          Id = 2,
          Name = "Test Tyre PQR",
          UnitPrice = 200,
          QuantityInStock = 10000,
          DateCreated = new DateTime(2022, 5, 3),
          DateModified = new DateTime(2022, 5, 3)
        },
        new TyreProduct
        {
          Id = 3,
          Name = "Test Tyre XYZ",
          UnitPrice = 300,
          QuantityInStock = 15000,
          DateCreated = new DateTime(2025, 5, 3),
          DateModified = new DateTime(2025, 5, 3)
        }
      };

      var mockRepo = new Mock<ITyreProductRepository>();

      mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(tyreProducts);
      //mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(tyreProducts[0]);
      mockRepo.Setup(r => r.GetByIdAsync(It.IsInRange<int>(1, 1000, Moq.Range.Inclusive))).ReturnsAsync(tyreProducts[0]);

      mockRepo.Setup(r => r.CreateAsync(It.IsAny<TyreProduct>()))
          .Returns((TyreProduct tyreProduct) =>
          {
            tyreProducts.Add(tyreProduct);
            return Task.CompletedTask;
          });

      return mockRepo;
    }
  }
}
