using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyreManagement.Core.Entities;

namespace TyreManagement.Core.Contracts.RepositoryContracts
{
  public interface ITyreProductRepository : IGenericRepository<TyreProduct>
  {
    Task<bool> IsNameUnique(string name);
  }
}
