using Microsoft.EntityFrameworkCore;
using UnitOfWorkPatternDemo.Data;
using UnitOfWorkPatternDemo.Repositories.Abstractions;
using UnitOfWorkPatternDemo.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Authorization services
builder.Services.AddAuthorization();

// Add Controllers services
builder.Services.AddControllers();

// Add Swagger/OpenAPI in one line
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Use Swagger with one line
    app.UseSwagger(); // Serves Swagger at /swagger/v1/swagger.json
    app.UseSwaggerUI(); // Serves the Swagger UI at /swagger
}

app.UseAuthorization();

// Map Controllers
app.MapControllers();

app.Run();