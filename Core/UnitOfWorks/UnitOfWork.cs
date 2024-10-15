using Microsoft.EntityFrameworkCore;
namespace Core.UnitOfWorks;
public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _context;
    public UnitOfWork(TContext context)
    {
        _context = context;
    }
    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
}