using Api.Domain.Models;
using Api.Repository.Interfaces;
using Api.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// inversão de controle
builder.Services.AddScoped<IRepository<User, Guid>, Repository<User, Guid>>();

builder.Services.AddScoped<IRepository<Ninja, int>, NinjaRepository>();



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
