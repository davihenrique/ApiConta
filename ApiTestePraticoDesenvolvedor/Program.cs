﻿using ApiTestePraticoDesenvolvedor.Application.Commands.Conta.Perfil;
using ApiTestePraticoDesenvolvedor.Application.Validations;
using ApiTestePraticoDesenvolvedor.Infra.DatabaseContext;
using ApiTestePraticoDesenvolvedor.Infra.Perfil;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(connectionString);
});

// Dependency injection Service
builder.Services.Scan(scan => scan
    .FromApplicationDependencies(a => a.FullName!.StartsWith("ApiTestePraticoDesenvolvedor.Application"))
    .AddClasses(c => c.Where(n => n.FullName!.EndsWith("Service")))
    .AsImplementedInterfaces()
);

// Dependency injection Repository
builder.Services.Scan(scan => scan
    .FromApplicationDependencies(a => a.FullName!.StartsWith("ApiTestePraticoDesenvolvedor.Infra"))
    .AddClasses(c => c.Where(n => n.FullName!.EndsWith("Repository")))
    .AsImplementedInterfaces()
);

// Fluentvalidation
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidateModelStateAttribute)); // Add the filter globally
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;  // Disable automatic model validation
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ContaValidator>();


// AutoMapper
builder.Services.AddAutoMapper(
    typeof(ContaServiceProfile),
    typeof(CompraRepositoryProfile)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
