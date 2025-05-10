using FluentValidation;
using TyreManagement.Core.Domain.Contracts.RepositoryContracts;

namespace TyreManagement.Core.Application.Features.TyreProduct.Commands.UpdateTyreProduct;

public class UpdateTyreProductCommandValidator : AbstractValidator<UpdateTyreProductCommand>
{
  private readonly ITyreProductRepository _tyreProductRepository;

  public UpdateTyreProductCommandValidator(ITyreProductRepository tyreProductRepository)
  {
    RuleFor(p => p.Id)
            .NotNull()
            .WithMessage("Id should not be null");

    RuleFor(p => p)
            .MustAsync(TyreProductMustExist)
            .WithMessage("Item not found");

    RuleFor(p => p.Name)
        .NotEmpty().WithMessage("{PropertyName} is required")
        .NotNull()
        .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters");

    RuleFor(q => q)
        .MustAsync(TyreProductNameUnique)
        .WithMessage("Name exists");


    this._tyreProductRepository = tyreProductRepository;
  }

  private async Task<bool> TyreProductMustExist(UpdateTyreProductCommand command, CancellationToken token)
  {
    var tyre = await _tyreProductRepository.GetByIdAsync(command.Id);
    return tyre != null;
  }

  private Task<bool> TyreProductNameUnique(UpdateTyreProductCommand command, CancellationToken token)
  {
    return _tyreProductRepository.IsNameUnique(command.Name);
  }
}
