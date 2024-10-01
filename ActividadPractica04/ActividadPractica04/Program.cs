using Microsoft.EntityFrameworkCore;
using RepositoryDLL.Data.Models;
using RepositoryDLL.Data.Repositories;
using RepositoryDLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DbTurnosContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString
("DefaultConnection")));

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

builder.Services.AddScoped<IService, Service>();

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
