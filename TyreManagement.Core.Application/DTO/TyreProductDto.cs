namespace TyreManagement.Core.DTO;

public class TyreProductDto
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public double UnitPrice { get; set; }
  public int QuantityInStock { get; set; }
}