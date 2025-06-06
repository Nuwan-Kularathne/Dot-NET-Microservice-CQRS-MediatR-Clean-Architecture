﻿using AutoMapper;
using Moq;
using Shouldly;
using TyreManagement.Core.Domain.Contracts.RepositoryContracts;
using TyreManagement.Core.DTO;
using TyreManagement.Core.Exceptions;
using TyreManagement.Core.Application.Features.TyreProduct.Commands.DeleteTyreProduct;
using TyreManagement.Core.Application.MappingProfiles;
using TyreManagement.UnitTests.Mocks;

namespace TyreManagement.UnitTests.Features.TyreProduct.Queries
{
  public class DeleteTyreProductCommandHandlerTests
  {
    private readonly Mock<ITyreProductRepository> _mockRepo;
    private IMapper _mapper;

    public DeleteTyreProductCommandHandlerTests()
    {
      _mockRepo = MockTyreProductRepository.GetMockTyreProductRepository();

      var mapperConfig = new MapperConfiguration(c =>
      {
        c.AddProfile<TyreProductMappingProfile>();
      });

      _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task DeleteTyreProductCommand_ShouldThrowNotFoundExceptionIfNotFound()
    {
      var handler = new DeleteTyreProductCommandHandler(_mockRepo.Object);

      await Should.ThrowAsync<NotFoundException>(async () =>
      {
        await handler.Handle(new DeleteTyreProductCommand() { Id = 9999 }, CancellationToken.None);
      });
    }
  }
}
