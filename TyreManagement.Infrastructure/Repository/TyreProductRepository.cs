using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyreManagement.Persistence.DatabaseContext;
using TyreManagement.Core.Entities;
using TyreManagement.Core.Contracts.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace TyreManagement.Persistence.Repository
{
  public class TyreProductRepository : GenericRepository<TyreProduct>, ITyreProductRepository
  {
    public TyreProductRepository(TyresDatabaseContext context) : base(context)
    {
    }

    public async Task<bool> IsNameUnique(string name)
    {
      return await _context.TyreProducts.AllAsync(q => q.Name != name);
    }
  }
}
