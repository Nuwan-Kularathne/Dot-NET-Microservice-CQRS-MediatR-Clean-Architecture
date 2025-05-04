using MediatR;

namespace TyreManagement.Core.Features.TyreProduct.Commands.DeleteTyreProduct
{
  public class DeleteTyreProductCommand : IRequest<Unit>
  {
    public int Id { get; set; }
  }
}
