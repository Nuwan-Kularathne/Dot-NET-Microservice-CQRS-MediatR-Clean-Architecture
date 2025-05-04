using AutoMapper;
using Moq;
using Shouldly;
using TyreManagement.Core.Contracts.RepositoryContracts;
using TyreManagement.Core.DTO;
using TyreManagement.Core.Exceptions;
using TyreManagement.Core.Features.TyreProduct.Commands.UpdateTyreProduct;
using TyreManagement.Core.Features.TyreProduct.Queries.GetAllTyreProducts;
using TyreManagement.Core.Features.TyreProduct.Queries.GetTyreProduct;
using TyreManagement.Core.MappingProfiles;
using TyreManagement.UnitTests.Mocks;

namespace TyreManagement.UnitTests.Features.TyreProduct.Queries
{
  public class UpdateTyreProductCommandHandlerTests
  {
    private readonly Mock<ITyreProductRepository> _mockRepo;
    private IMapper _mapper;

    public UpdateTyreProductCommandHandlerTests()
    {
      _mockRepo = MockTyreProductRepository.GetMockTyreProductRepository();

      var mapperConfig = new MapperConfiguration(c =>
      {
        c.AddProfile<TyreProductMappingProfile>();
      });

      _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task UpdateTyreProductCommand_ShouldThrowBadRequestExceptionIfNameIsNotUnique()
    {
      var handler = new UpdateTyreProductCommandHandler(_mapper, _mockRepo.Object);

      await Should.ThrowAsync<BadRequestException>(async () =>
      {
        await handler.Handle(new UpdateTyreProductCommand() { Id = 1, Name = "Test Tyre PQR", QuantityInStock = 10, UnitPrice = 10 }, CancellationToken.None);
      });
    }
  }
}
