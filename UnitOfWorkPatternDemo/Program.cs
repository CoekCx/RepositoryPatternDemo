using Microsoft.EntityFrameworkCore;
using UnitOfWorkPatternDemo.Data;
using UnitOfWorkPatternDemo.Repositories.Abstractions;
using UnitOfWorkPatternDemo.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Configure PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
app.MapControllers();
app.Run();