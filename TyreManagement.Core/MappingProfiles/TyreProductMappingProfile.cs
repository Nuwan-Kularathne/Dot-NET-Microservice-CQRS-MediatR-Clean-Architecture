using AutoMapper;
using TyreManagement.Core.DTO;
using TyreManagement.Core.Entities;
using TyreManagement.Core.Features.TyreProduct.Commands.CreateTyreProduct;
using TyreManagement.Core.Features.TyreProduct.Commands.UpdateTyreProduct;

namespace TyreManagement.Core.MappingProfiles
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
