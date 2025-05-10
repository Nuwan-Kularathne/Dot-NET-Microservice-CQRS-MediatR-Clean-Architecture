using FluentValidation.Results;

namespace TyreManagement.Core.Exceptions;

public class BadRequestException : Exception
{
  public BadRequestException(string message) : base(message)
  {

  }

  public List<string> ValidationErrors { get; set; } = new();

  public BadRequestException(string message, ValidationResult validationResult) : base(message)
  {
    foreach (var error in validationResult.Errors)
    {
      ValidationErrors.Add(error.ErrorMessage);
    }
  }
}
