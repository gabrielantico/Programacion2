using Microsoft.EntityFrameworkCore;
using RepositoryDLL.Business;
using RepositoryDLL.Data.Models;
using RepositoryDLL.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TurnosDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IServicesRepository, ServicesRepository>();

builder.Services.AddScoped<ITurnRepository, TurnRepository>();

builder.Services.AddScoped<ITurnManager, TurnManager>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
