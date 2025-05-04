using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyreManagement.Core.Contracts.RepositoryContracts;
using TyreManagement.Core.Exceptions;

namespace TyreManagement.Core.Features.TyreProduct.Commands.DeleteTyreProduct
{
  public class DeleteTyreProductCommandHandler : IRequestHandler<DeleteTyreProductCommand, Unit>
  {
    private readonly ITyreProductRepository _tyreProductRepository;

    public DeleteTyreProductCommandHandler(ITyreProductRepository TyreProductRepository)
    {
      _tyreProductRepository = TyreProductRepository;
    }

    public async Task<Unit> Handle(DeleteTyreProductCommand request, CancellationToken cancellationToken)
    {
      // Retrieve domain entity object
      var tyreProductToDelete = await _tyreProductRepository.GetByIdAsync(request.Id);

      // Verify that record exists
      if (tyreProductToDelete == null)
        throw new NotFoundException(nameof(TyreProduct), request.Id);

      // Remove from database
      await _tyreProductRepository.DeleteAsync(tyreProductToDelete);

      // Retun default
      return Unit.Value;
    }
  }
}
