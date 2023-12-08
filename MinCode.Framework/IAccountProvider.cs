namespace MinCode.Framework
{
  public interface IAccountProvider
  {
    /// <summary>
    /// Indicates if there is an authenticated user
    /// </summary>
    bool IsAuthenticated { get; }
    /// <summary>
    /// Returns the username
    /// </summary>
    string UserName { get; }
    /// <summary>
    /// Returns the full name of the user
    /// </summary>
    string FullName { get; }
    /// <summary>
    /// Determines if the user has a specific right
    /// </summary>
    /// <param name="right">right to check</param>
    /// <returns></returns>
    bool HasRight(string right);
  }
}
