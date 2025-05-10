using AutoMapper;
using Moq;
using Shouldly;
using TyreManagement.Core.Domain.Contracts.RepositoryContracts;
using TyreManagement.Core.DTO;
using TyreManagement.Core.Application.Features.TyreProduct.Queries.GetTyreProduct;
using TyreManagement.Core.Application.MappingProfiles;
using TyreManagement.UnitTests.Mocks;

namespace TyreManagement.UnitTests.Features.TyreProduct.Queries
{
  public class GetTyreProductQueryHandlerTests
  {
    private readonly Mock<ITyreProductRepository> _mockRepo;
    private IMapper _mapper;

    public GetTyreProductQueryHandlerTests()
    {
      _mockRepo = MockTyreProductRepository.GetMockTyreProductRepository();

      var mapperConfig = new MapperConfiguration(c =>
      {
        c.AddProfile<TyreProductMappingProfile>();
      });

      _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetTyreProductQuery_ShouldReturnCorrectType()
    {
      var handler = new GetTyreProductQueryHandler(_mapper, _mockRepo.Object);
      var result = await handler.Handle(new GetTyreProductQuery(1), CancellationToken.None);
      result.ShouldBeOfType<TyreProductDto>();
    }
  }
}
