using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Core.Repositories;
public class EfRepositoryBase<TContext, T, TId> : IGenericRepository<T, TId>
    where T : Entity<TId>, new()
    where TContext : DbContext
{
    protected TContext Context { get; }
    private readonly DbSet<T> _dbSet;
    public EfRepositoryBase(TContext context)
    {
        Context = context;
        _dbSet = context.Set<T>();
    }
    public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public async Task<bool> AnyAsync(TId id) => await _dbSet.AnyAsync(x => x.Id.Equals(id));
    public void Delete(T entity) => _dbSet.Remove(entity);
    public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();
    public async ValueTask<T?> GetByIdAsync(TId id) => await _dbSet.FindAsync(id);
    public void Update(T entity) => _dbSet.Update(entity);
    public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();
}