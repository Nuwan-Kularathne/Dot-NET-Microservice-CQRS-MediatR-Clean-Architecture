using AutoMapper;
using Moq;
using Shouldly;
using TyreManagement.Core.Contracts.RepositoryContracts;
using TyreManagement.Core.DTO;
using TyreManagement.Core.Exceptions;
using TyreManagement.Core.Features.TyreProduct.Commands.CreateTyreProduct;
using TyreManagement.Core.Features.TyreProduct.Queries.GetAllTyreProducts;
using TyreManagement.Core.Features.TyreProduct.Queries.GetTyreProduct;
using TyreManagement.Core.MappingProfiles;
using TyreManagement.UnitTests.Mocks;

namespace TyreManagement.UnitTests.Features.TyreProduct.Queries
{
  public class CreateTyreProductCommandHandlerTests
  {
    private readonly Mock<ITyreProductRepository> _mockRepo;
    private IMapper _mapper;

    public CreateTyreProductCommandHandlerTests()
    {
      _mockRepo = MockTyreProductRepository.GetMockTyreProductRepository();

      var mapperConfig = new MapperConfiguration(c =>
      {
        c.AddProfile<TyreProductMappingProfile>();
      });

      _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task CreateTyreProductCommand_ShouldThrowBadRequestExceptionIfNameIsNotUnique()
    {
      var handler = new CreateTyreProductCommandHandler(_mapper, _mockRepo.Object);

      await Should.ThrowAsync<BadRequestException>(async () =>
      {
        await handler.Handle(new CreateTyreProductCommand() { Name = "Test Tyre ABC", QuantityInStock = 10, UnitPrice = 10 }, CancellationToken.None);
      });
    }
  }
}
