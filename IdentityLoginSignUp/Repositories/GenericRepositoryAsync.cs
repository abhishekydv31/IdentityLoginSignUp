using IdentityLoginSignUp.Areas.Identity.Data;
using IdentityLoginSignUp.Interfaces;
using Microsoft.EntityFrameworkCore;

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
{
    private readonly ApplicationDBContext _dbContext;
    public GenericRepositoryAsync(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }
    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }
    public Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }
    public Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
}