using UnitOfWorkPatternDemo.Data;
using UnitOfWorkPatternDemo.Models;
using UnitOfWorkPatternDemo.Repositories.Abstractions;

namespace UnitOfWorkPatternDemo.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Products = new Repository<Product>(_context);
        Orders = new Repository<Order>(_context);
    }

    public IRepository<Product> Products { get; private set; }
    public IRepository<Order> Orders { get; private set; }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}