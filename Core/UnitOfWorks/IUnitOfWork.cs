namespace Core.UnitOfWorks;
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}