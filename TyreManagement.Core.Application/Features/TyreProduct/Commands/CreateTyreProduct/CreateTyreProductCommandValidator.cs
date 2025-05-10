using FluentValidation;
using TyreManagement.Core.Domain.Contracts.RepositoryContracts;

namespace TyreManagement.Core.Application.Features.TyreProduct.Commands.CreateTyreProduct;

public class CreateTyreProductCommandValidator : AbstractValidator<CreateTyreProductCommand>
{
  private readonly ITyreProductRepository _tyreProductRepository;

  public CreateTyreProductCommandValidator(ITyreProductRepository tyreProductRepository)
  {
    RuleFor(p => p.Name)
        .NotEmpty().WithMessage("{PropertyName} is required")
        .NotNull()
        .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters");

    RuleFor(q => q)
        .MustAsync(TyreProductNameUnique)
        .WithMessage("Name exists");


    this._tyreProductRepository = tyreProductRepository;
  }

  private Task<bool> TyreProductNameUnique(CreateTyreProductCommand command, CancellationToken token)
  {
    return _tyreProductRepository.IsNameUnique(command.Name);
  }
}
