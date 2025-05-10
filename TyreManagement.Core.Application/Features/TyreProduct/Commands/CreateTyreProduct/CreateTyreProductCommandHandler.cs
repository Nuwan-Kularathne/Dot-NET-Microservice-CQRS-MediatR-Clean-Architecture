using AutoMapper;
using MediatR;
using TyreManagement.Core.Domain.Contracts.RepositoryContracts;
using TyreManagement.Core.Exceptions;

namespace TyreManagement.Core.Application.Features.TyreProduct.Commands.CreateTyreProduct
{
  public class CreateTyreProductCommandHandler : IRequestHandler<CreateTyreProductCommand, int>
  {
    private readonly IMapper _mapper;
    private readonly ITyreProductRepository _tyreProductRepository;

    public CreateTyreProductCommandHandler(IMapper mapper, ITyreProductRepository typeProductRepository)
    {
      _mapper = mapper;
      _tyreProductRepository = typeProductRepository;
    }
    public async Task<int> Handle(CreateTyreProductCommand request, CancellationToken cancellationToken)
    {
      // Validate incoming data
      var validator = new CreateTyreProductCommandValidator(_tyreProductRepository);
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Any())
        throw new BadRequestException("Invalid Request", validationResult);

      // convert to domain entity object
      var tyreProductToCreate = _mapper.Map<Domain.Entities.TyreProduct>(request);

      // add to database
      await _tyreProductRepository.CreateAsync(tyreProductToCreate);

      // retun record id
      return tyreProductToCreate.Id;
    }
  }
}
