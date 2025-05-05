using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyreManagement.Core.Contracts.RepositoryContracts;
using TyreManagement.Core.Entities.Common;
using TyreManagement.Persistence.DatabaseContext;

namespace TyreManagement.Persistence.Repository
{
  public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
  {
    protected readonly TyresDatabaseContext _context;

    public GenericRepository(TyresDatabaseContext context)
    {
      this._context = context;
    }

    public async Task CreateAsync(T entity)
    {
      await _context.AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
      _context.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
      return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
  }
}
