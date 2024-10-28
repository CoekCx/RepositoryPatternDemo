using Microsoft.EntityFrameworkCore;
using UnitOfWorkPatternDemo.Models;

namespace UnitOfWorkPatternDemo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
}