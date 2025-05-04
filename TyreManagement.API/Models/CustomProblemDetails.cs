using Microsoft.AspNetCore.Mvc;

namespace TyreManagement.API.Models
{
  public class CustomProblemDetails : ProblemDetails
  {
    public IList<string>? Errors { get; set; }
  }
}
