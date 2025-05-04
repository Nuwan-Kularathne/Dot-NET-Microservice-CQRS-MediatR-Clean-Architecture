using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TyreManagement.Core.Contracts.RepositoryContracts;
using TyreManagement.Persistence.DatabaseContext;
using TyreManagement.Persistence.Repository;

namespace TyreManagement.Persistence;
public static class DependencyInjection
{
  /// <summary>
  /// Add infrastructure services to IoC container.
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<TyresDatabaseContext>(options => {
      options.UseSqlServer(configuration.GetConnectionString("TyresDatabaseConnectionString"));
    });

    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    services.AddScoped<ITyreProductRepository, TyreProductRepository>();

    return services;
  }
}
