using Contract;
using Contract.Model;
using Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DomainRegister.Instance
    .Register<ContractDetail>("Contract")
    .Register<Template>("Template")
    .Build();

string connection = "";
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connection));
builder.Services.AddDataContext<DataContext>(options => options.UseNpgsql(connection));
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});

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

