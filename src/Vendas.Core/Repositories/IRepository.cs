namespace Vendas.Core.Repositories;

public interface IRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(object id);
    Task AddAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
    Task SaveChangesAsync();
}
