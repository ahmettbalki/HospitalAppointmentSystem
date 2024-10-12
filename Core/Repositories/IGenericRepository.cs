using Core.Entities;
using System.Linq.Expressions;
namespace Core.Repositories;
public interface IGenericRepository<T, TId> where T : Entity<TId>, new()
{
    IQueryable<T> GetAll();
    ValueTask<T> GetByIdAsync(TId id);
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    Task<bool> AnyAsync(TId id);
    ValueTask AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}