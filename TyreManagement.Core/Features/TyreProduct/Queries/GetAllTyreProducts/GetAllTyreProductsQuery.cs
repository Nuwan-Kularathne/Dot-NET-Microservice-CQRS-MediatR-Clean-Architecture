using MediatR;
using TyreManagement.Core.DTO;

namespace TyreManagement.Core.Features.TyreProduct.Queries.GetAllTyreProducts
{
  public record GetAllTyreProductsQuery : IRequest<List<TyreProductDto>>;
}
