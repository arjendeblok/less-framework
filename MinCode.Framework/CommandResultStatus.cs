namespace MinCode.Framework
{
  /// <summary>
  /// Status of the result of the execution of a command
  /// </summary>
  public enum CommandResultStatus
  {
    Success,
    Unauthenticated,
    Forbidden,
    ValidationFailure,
    UnprocessableFailure,
    NotFound,
    Exception
  }
}
