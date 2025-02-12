using Microsoft.EntityFrameworkCore;
using PocketBook.Core.IConfiguration;
using PocketBook.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();  // !!Register controllers
builder.Services.AddOpenApi();
// adding the Unit of work to the DI container
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Logging.SetMinimumLevel(LogLevel.Debug);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers(); // !!Ensures API routes work

app.Run();

