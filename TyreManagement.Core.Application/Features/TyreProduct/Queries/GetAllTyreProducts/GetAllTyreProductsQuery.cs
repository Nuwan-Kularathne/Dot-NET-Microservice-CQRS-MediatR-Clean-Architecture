using MediatR;
using TyreManagement.Core.DTO;

namespace TyreManagement.Core.Application.Features.TyreProduct.Queries.GetAllTyreProducts
{
  public record GetAllTyreProductsQuery : IRequest<List<TyreProductDto>>;
}
