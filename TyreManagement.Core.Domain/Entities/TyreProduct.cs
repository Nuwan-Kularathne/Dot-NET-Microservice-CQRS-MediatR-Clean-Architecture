using TyreManagement.Core.Domain.Entities.Common;

namespace TyreManagement.Core.Domain.Entities
{
  public class TyreProduct: BaseEntity
  {
    public required string Name { get; set; }
    public double UnitPrice { get; set; }
    public int QuantityInStock { get; set; }
  }
}
