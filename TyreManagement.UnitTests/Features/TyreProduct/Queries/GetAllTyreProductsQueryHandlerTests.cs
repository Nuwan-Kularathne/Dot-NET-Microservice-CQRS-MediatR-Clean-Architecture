using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyreManagement.Core.Contracts.RepositoryContracts;
using TyreManagement.Core.DTO;
using TyreManagement.Core.Features.TyreProduct.Queries.GetAllTyreProducts;
using TyreManagement.Core.MappingProfiles;
using TyreManagement.UnitTests.Mocks;

namespace TyreManagement.UnitTests.Features.TyreProduct.Queries
{
  public class GetAllTyreProductsQueryHandlerTests
  {
    private readonly Mock<ITyreProductRepository> _mockRepo;
    private IMapper _mapper;

    public GetAllTyreProductsQueryHandlerTests()
    {
      _mockRepo = MockTyreProductRepository.GetMockTyreProductRepository();

      var mapperConfig = new MapperConfiguration(c =>
      {
        c.AddProfile<TyreProductMappingProfile>();
      });

      _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetAllTyreProductsQuery_ShouldReturnCorrectType()
    {
      var handler = new GetAllTyreProductsQueryHandler(_mapper, _mockRepo.Object);
      var result = await handler.Handle(new GetAllTyreProductsQuery(), CancellationToken.None);
      result.ShouldBeOfType<List<TyreProductDto>>();
    }

    [Fact]
    public async Task GetAllTyreProductsQuery_ShouldReturnCorrectNumberOfRecords()
    {
      var handler = new GetAllTyreProductsQueryHandler(_mapper, _mockRepo.Object);
      var result = await handler.Handle(new GetAllTyreProductsQuery(), CancellationToken.None);
      result.Count.ShouldBe(3);
    }
  }
}
