using AutoMapper;
using MediatR;
using TyreManagement.Core.Contracts.RepositoryContracts;
using TyreManagement.Core.DTO;
using TyreManagement.Core.Exceptions;

namespace TyreManagement.Core.Features.TyreProduct.Queries.GetTyreProduct
{
  public class GetTyreProductQueryHandler : IRequestHandler<GetTyreProductQuery, TyreProductDto>
  {
    private readonly IMapper _mapper;
    private readonly ITyreProductRepository _tyreProductRepository;

    public GetTyreProductQueryHandler(IMapper mapper, ITyreProductRepository tyreProductRepository)
    {
      _mapper = mapper;
      _tyreProductRepository = tyreProductRepository;
    }

    public async Task<TyreProductDto> Handle(GetTyreProductQuery request, CancellationToken cancellationToken)
    {
      // Query the database
      var tyreProduct = await _tyreProductRepository.GetByIdAsync(request.Id);

      // Verify that record exists
      if (tyreProduct == null)
        throw new NotFoundException(nameof(TyreProduct), request.Id);

      // Convert data object to DTO object
      var data = _mapper.Map<TyreProductDto>(tyreProduct);

      // return DTO object
      return data;
    }
  }
}
