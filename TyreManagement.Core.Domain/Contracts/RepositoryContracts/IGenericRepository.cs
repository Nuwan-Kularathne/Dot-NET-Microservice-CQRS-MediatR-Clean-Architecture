

using TyreManagement.Core.Domain.Entities.Common;

namespace TyreManagement.Core.Domain.Contracts.RepositoryContracts
{
  public interface IGenericRepository<T> where T : BaseEntity
  {
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
  }
}
