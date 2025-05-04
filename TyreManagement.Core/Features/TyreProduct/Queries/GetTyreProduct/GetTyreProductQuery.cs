using MediatR;
using TyreManagement.Core.DTO;

namespace TyreManagement.Core.Features.TyreProduct.Queries.GetTyreProduct;

public record GetTyreProductQuery(int Id) : IRequest<TyreProductDto>;
