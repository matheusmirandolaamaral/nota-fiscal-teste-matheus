using nota_fiscal_teste.Configurations;
using nota_fiscal_teste.Repositories;
using nota_fiscal_teste.Repositories.Impl;
using nota_fiscal_teste.Services;
using nota_fiscal_teste.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogConfiguration();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddScoped<IProductRepository, ProductRepositoryImpl>();

builder.Services.AddScoped<IProductService, ProductServiceImpl>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
