using System.Linq.Expressions;

namespace Persistence.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
	List<T> Get();
    Task<List<T>> GetAsync();
    List<T> GetWhere(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
    T GetSingle(Func<T, bool> predicate);
    Task<T> GetSingleAsync(Func<T, bool> predicate);
    T GetById(long id);
    Task<T> GetByIdAsync(long id);
    bool Add(T value);
    Task<bool> AddAsync(T value);
    bool Remove(T value);
    Task<bool> RemoveAsync(T value);
    bool Remove(long id);
    Task<bool> RemoveAsync(long id);
    bool Update(T model, long id);
    Task<bool> UpdateAsync(T model, long id);
    bool Save();
    Task<bool> SaveAsync();
}