namespace MinCode.Framework
{
  public interface IRepository<TAggregateRoot>
    where TAggregateRoot : class, IAggregateRoot
  {
    /// <summary>
    /// Gets an aggregate root from its id
    /// </summary>
    /// <param name="id">id of aggragate root</param>
    /// <returns>the entity or throws an exception</returns>
    Task<TAggregateRoot> GetRequiredAsync(int id);
    /// <summary>
    /// Gets an aggregate root from its id
    /// </summary>
    /// <param name="id">id of aggragate root</param>
    /// <returns>the entity or null</returns>
    Task<TAggregateRoot?> GetAsync(int id);
    /// <summary>
    /// Checks if an aggregate root exists with this id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> HasWithIdAsync(int id);
    /// <summary>
    /// Adds an entity
    /// </summary>
    /// <param name="entity"></param>
    void Add(TAggregateRoot entity);
    /// <summary>
    /// Deletes an entity
    /// </summary>
    /// <param name="id">Identifier of the entity</param>
    Task DeleteAsync(int id);
    /// <summary>
    /// Saves explicitly the changes to the database
    /// </summary>
    /// <returns></returns>
    Task SaveChangesAsync();
  }
}
