using FluentValidation.Results;

namespace MinCode.Framework
{
  /// <summary>
  /// Result of the execution of a command
  /// </summary>
  /// <param name="Status">status</param>
  /// <param name="Errors">list of validation errors</param>
  public record CommandResult(CommandResultStatus Status, List<ValidationFailure>? Errors = null);

  /// <summary>
  /// Result of the execution of a command with additional information
  /// </summary>
  /// <typeparam name="TCommandResult"></typeparam>
  /// <param name="Status">status</param>
  /// <param name="Result">additional information like an entity id</param>
  /// <param name="Errors">list of validation errors</param>
  public record CommandResult<TCommandResult>(
    CommandResultStatus Status, TCommandResult Result, List<ValidationFailure>? Errors = null)
    : CommandResult(Status, Errors);
}
