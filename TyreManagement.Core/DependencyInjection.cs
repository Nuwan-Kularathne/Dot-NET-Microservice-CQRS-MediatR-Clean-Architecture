using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace TyreManagement.Core;
public static class DependencyInjection
{
  /// <summary>
  /// Add core services to IoC container.
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection AddCoreServices(this IServiceCollection services)
  {
    services.AddAutoMapper(Assembly.GetExecutingAssembly());
    services.AddMediatR(Assembly.GetExecutingAssembly());
    return services;
  }
}
