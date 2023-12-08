namespace MinCode.Framework
{
  /// <summary>
  /// Result of the execution of a command
  /// </summary>
  /// <param name="Status">status</param>
  public record CommandResult(CommandResultStatus Status);

  /// <summary>
  /// Result of the execution of a command with additional information
  /// </summary>
  /// <typeparam name="TCommandResult"></typeparam>
  /// <param name="Status">status</param>
  /// <param name="Result">additional information like an entity id</param>
  public record CommandResult<TCommandResult>(
    CommandResultStatus Status, TCommandResult Result);
}
