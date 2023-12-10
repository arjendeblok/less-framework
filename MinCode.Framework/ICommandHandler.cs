namespace MinCode.Framework
{
  /// <summary>
  /// Command handler
  /// </summary>
  /// <typeparam name="TCommand">the command type</typeparam>
  public interface ICommandHandler<TCommand>
    where TCommand : class, ICommand
  {
    /// <summary>
    /// Executes the command
    /// </summary>
    /// <param name="command">the command to execute</param>
    /// <param name="ct">cancel token</param>
    /// <returns>a command result</returns>
    Task<CommandResult> HandleAsync(TCommand command, CancellationToken ct = default);
  }
}
