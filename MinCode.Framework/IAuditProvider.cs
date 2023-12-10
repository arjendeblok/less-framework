namespace MinCode.Framework
{
  /// <summary>
  /// Interface to an audit provider
  /// </summary>
  public interface IAuditProvider
  {
    /// <summary>
    /// Indicates if auditing is enabled
    /// </summary>
    bool IsAuditEnabled { get; }

    /// <summary>
    /// Audits a command given by a user
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <param name="result">Result of the handling</param>
    /// <param name="message">Message to log</param>
    /// <param name="user">User initiated the command</param>
    /// <param name="command">The command executed</param>
    /// <returns></returns>
    Task AuditAsync<TCommand>(CommandResultStatus status,
      string message, string user, TCommand? command)
      where TCommand : class, ICommand;

    Task AuditAsync<TCommand, TAggregateRoot>(CommandResultStatus status,
      string message, string user, TCommand? command, TAggregateRoot? entity)
      where TCommand : class, ICommand;
  }
}
