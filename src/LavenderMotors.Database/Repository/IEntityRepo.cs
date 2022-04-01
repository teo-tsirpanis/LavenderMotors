namespace LavenderMotors.Database.Repository;

public interface IEntityRepo<T>
{
    IAsyncEnumerable<T> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
}
