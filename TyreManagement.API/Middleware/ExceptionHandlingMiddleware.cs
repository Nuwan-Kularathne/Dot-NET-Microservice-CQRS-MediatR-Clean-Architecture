using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using TyreManagement.API.Models;
using TyreManagement.Core.Exceptions;

namespace TyreManagement.API.Middleware;

public class ExceptionHandlingMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<ExceptionHandlingMiddleware> _logger;

  public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  public async Task Invoke(HttpContext httpContext)
  {
    try
    {
      await _next(httpContext);
    }
    catch (Exception ex)
    {
      await HandleExceptionAsync(httpContext, ex);
    }
  }

  private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
  {
    HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
    CustomProblemDetails problem = new();

    switch (ex)
    {
      case BadRequestException badRequestException:
        statusCode = HttpStatusCode.BadRequest;
        problem = new CustomProblemDetails
        {
          Title = badRequestException.Message,
          Status = (int)statusCode,
          Detail = badRequestException.InnerException?.Message,
          Type = nameof(BadRequestException),
          Errors = badRequestException.ValidationErrors
        };
        break;
      case NotFoundException NotFound:
        statusCode = HttpStatusCode.NotFound;
        problem = new CustomProblemDetails 
        {
          Title = NotFound.Message,
          Status = (int)statusCode,
          Type = nameof(NotFoundException),
          Detail = NotFound.InnerException?.Message,
        };
        break;
      default:
        problem = new CustomProblemDetails
        {
          Title = ex.Message,
          Status = (int)statusCode,
          Type = nameof(HttpStatusCode.InternalServerError),
          Detail = ex.StackTrace,
        };
        break;
    }

    httpContext.Response.StatusCode = (int)statusCode;
    await httpContext.Response.WriteAsJsonAsync(problem);

  }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlingMiddlewareExtensions
{
  public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
  {
      return builder.UseMiddleware<ExceptionHandlingMiddleware>();
  }
}
