using TyreManagement.Core.Entities.Common;

namespace TyreManagement.Core.Entities
{
  public class TyreProduct: BaseEntity
  {
    public required string Name { get; set; }
    public double UnitPrice { get; set; }
    public int QuantityInStock { get; set; }
  }
}
