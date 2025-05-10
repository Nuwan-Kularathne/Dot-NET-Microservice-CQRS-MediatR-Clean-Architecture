using MediatR;

namespace TyreManagement.Core.Application.Features.TyreProduct.Commands.DeleteTyreProduct
{
  public class DeleteTyreProductCommand : IRequest<Unit>
  {
    public int Id { get; set; }
  }
}
