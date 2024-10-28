using UnitOfWorkPatternDemo.Models;

namespace UnitOfWorkPatternDemo.Repositories.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IRepository<Product> Products { get; }
    IRepository<Order> Orders { get; }
    Task<int> CompleteAsync();
}