using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Core.Repositories;
public class EfRepositoryBase<TContext, T, TId>(TContext context) : IGenericRepository<T, TId>
    where T : Entity<TId>, new()
    where TContext : DbContext
{
    protected TContext Context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();
    public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public Task<bool> AnyAsync(TId id) => _dbSet.AnyAsync(x => x.Id.Equals(id));
    public void Delete(T entity) => _dbSet.Remove(entity);
    public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();
    public ValueTask<T> GetByIdAsync(TId id) => _dbSet.FindAsync(id);
    public void Update(T entity) => _dbSet.Update(entity);
    public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();
}