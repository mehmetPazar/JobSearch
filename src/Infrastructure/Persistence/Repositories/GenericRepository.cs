using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	private readonly ApplicationDbContext _dbContext;

    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

	public bool Add(T value)
    {
        _dbContext.Set<T>().Add(value);
        return Save();
    }

    public List<T> Get()  // İlişkisel???
    {
        return _dbContext.Set<T>().AsNoTracking().ToList();
    }

    public T GetById(long id)
    {
        return _dbContext.Set<T>().Find(id);
    }

    public T GetSingle(Func<T, bool> predicate)
    {
        return _dbContext.Set<T>().SingleOrDefault(predicate);
    }

    public List<T> GetWhere(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>().Where(predicate).ToList();
    }

    public bool Remove(T value)
    {
        _dbContext.Set<T>().Remove(value);
        return Save();
    }

    public bool Remove(long id)
    {
        T entity = _dbContext.Set<T>().Find(id);
        if(entity is null)
            return false;
        
        _dbContext.Set<T>().Remove(entity);
        return Save();
    }

    public bool Update(T model, long id)
    {
        T entity = _dbContext.Set<T>().Find(id);
        if(entity is null)
            return false;
        
        _dbContext.Entry(entity).CurrentValues.SetValues(model);
        return Save();
    }

    public bool Save()
    {
        return _dbContext.SaveChanges() > 0;
    }

    public async Task<List<T>> GetAsync() // İlişkisel???
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbContext.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<T> GetSingleAsync(Func<T, bool> predicate)
    {
        return await Task.FromResult(_dbContext.Set<T>().SingleOrDefault(predicate));
    }

    public async Task<T> GetByIdAsync(long id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<bool> AddAsync(T value)
    {
        await _dbContext.Set<T>().AddAsync(value);
        return await SaveAsync();
    }

    public async Task<bool> RemoveAsync(T value)
    {
        _dbContext.Set<T>().Remove(value);
        return await SaveAsync();
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        if (entity == null)
            return false;

        _dbContext.Set<T>().Remove(entity);
        return await SaveAsync();
    }

    public async Task<bool> UpdateAsync(T model, long id)
    {
        T entity = await _dbContext.Set<T>().FindAsync(id);
        if(entity is null)
            return false;
        
        _dbContext.Entry(entity).CurrentValues.SetValues(model);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return (await _dbContext.SaveChangesAsync()) > 0;
    }
}