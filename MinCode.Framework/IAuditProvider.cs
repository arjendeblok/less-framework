namespace MinCode.Framework
{
  /// <summary>
  /// Result of an operation
  /// </summary>
  public enum AuditResult
  {
    Handled, Unauthenticated, Unauthorized, Failed
  }

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
    Task AuditAsync<TCommand>(AuditResult result,
      string message, string user, TCommand? command)
      where TCommand : class, ICommand;
  }
}
