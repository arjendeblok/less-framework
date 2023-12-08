namespace MinCode.Framework
{
  /// <summary>
  /// Tag to see this class as an entity
  /// </summary>
  public interface IEntity
  {
  }

  /// <summary>
  /// Tag to see this class an an aggregate root
  /// </summary>
  public interface IAggregateRoot
    : IEntity
  {

  }
}
