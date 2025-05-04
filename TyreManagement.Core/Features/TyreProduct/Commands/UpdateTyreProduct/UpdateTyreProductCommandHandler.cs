using AutoMapper;
using MediatR;
using TyreManagement.Core.Contracts.RepositoryContracts;
using TyreManagement.Core.Exceptions;
using TyreManagement.Core.Entities;

namespace TyreManagement.Core.Features.TyreProduct.Commands.UpdateTyreProduct
{
  public class UpdateTyreProductCommandHandler : IRequestHandler<UpdateTyreProductCommand, Unit>
  {
    private readonly IMapper _mapper;
    private readonly ITyreProductRepository _tyreProductRepository;

    public UpdateTyreProductCommandHandler(IMapper mapper, ITyreProductRepository typeProductRepository)
    {
      _mapper = mapper;
      _tyreProductRepository = typeProductRepository;
    }
    public async Task<Unit> Handle(UpdateTyreProductCommand request, CancellationToken cancellationToken)
    {
      // Validate incoming data
      var validator = new UpdateTyreProductCommandValidator(_tyreProductRepository);
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Any())
      {
        throw new BadRequestException("Invalid Request", validationResult);
      }
      // Convert to domain entity object
      var tyreProductToUpdate = _mapper.Map<Entities.TyreProduct>(request);

      // Add to database
      await _tyreProductRepository.UpdateAsync(tyreProductToUpdate);

      // return Unit value
      return Unit.Value;
    }
  }
}
