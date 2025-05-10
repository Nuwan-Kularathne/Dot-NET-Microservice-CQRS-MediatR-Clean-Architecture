using TyreManagement.Core.Domain.Contracts.RepositoryContracts;
using TyreManagement.Core.Domain.Entities;

namespace TyreManagement.Core.Domain.Contracts.RepositoryContracts
{
  public interface ITyreProductRepository : IGenericRepository<TyreProduct>
  {
    Task<bool> IsNameUnique(string name);
  }
}
