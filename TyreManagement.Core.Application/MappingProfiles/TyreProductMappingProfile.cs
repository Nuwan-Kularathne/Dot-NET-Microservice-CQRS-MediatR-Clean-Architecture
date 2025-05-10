using AutoMapper;
using TyreManagement.Core.DTO;
using TyreManagement.Core.Domain.Entities;
using TyreManagement.Core.Application.Features.TyreProduct.Commands.CreateTyreProduct;
using TyreManagement.Core.Application.Features.TyreProduct.Commands.UpdateTyreProduct;

namespace TyreManagement.Core.Application.MappingProfiles
{
  public class TyreProductMappingProfile : Profile
  {
    public TyreProductMappingProfile()
    {
      CreateMap<CreateTyreProductCommand, TyreProduct>();
      CreateMap<UpdateTyreProductCommand, TyreProduct>();
      CreateMap<TyreProduct, TyreProductDto>();
    }
  }
}
