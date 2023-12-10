namespace MinCode.Framework
{
  /// <summary>
  /// Tag to see this (record) class as a command
  /// </summary>
  /// <remarks>
  /// This framework assumes the one type of a command belongs to zero or one type of entity
  /// </remarks>
  public interface ICommand
  {
  }
  
  /// <summary>
  /// Tag to see this (record) class as a command for one existing entity
  /// </summary>
  public interface IInstanceCommand : ICommand {
    int Id { get; }
  }
}
