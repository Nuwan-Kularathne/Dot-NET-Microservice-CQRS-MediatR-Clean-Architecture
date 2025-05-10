using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyreManagement.Core.Domain.Contracts.RepositoryContracts;
using TyreManagement.Core.DTO;

namespace TyreManagement.Core.Application.Features.TyreProduct.Queries.GetAllTyreProducts
{
  public class GetAllTyreProductsQueryHandler : IRequestHandler<GetAllTyreProductsQuery, List<TyreProductDto>>
  {
    private readonly IMapper _mapper;
    private readonly ITyreProductRepository _tyreProductRepository;

    public GetAllTyreProductsQueryHandler(IMapper mapper,
        ITyreProductRepository tyreProductRepository)
    {
      this._mapper = mapper;
      this._tyreProductRepository = tyreProductRepository;
    }

    public async Task<List<TyreProductDto>> Handle(GetAllTyreProductsQuery request, CancellationToken cancellationToken)
    {
      // Query the database
      var tyreProducts = await _tyreProductRepository.GetAsync();

      // Convert data objects to DTO objects
      var data = _mapper.Map<List<TyreProductDto>>(tyreProducts);

      // Return list of DTO object
      return data;
    }
  }
}
