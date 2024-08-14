using ApiConta.Application.Commands.Conta.Perfil;
using ApiConta.Application.Validations;
using ApiConta.Infra.DatabaseContext;
using ApiConta.Infra.Perfil;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

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
    .FromApplicationDependencies(a => a.FullName!.StartsWith("ApiConta.Application"))
    .AddClasses(c => c.Where(n => n.FullName!.EndsWith("Service")))
    .AsImplementedInterfaces()
);

// Dependency injection Repository
builder.Services.Scan(scan => scan
    .FromApplicationDependencies(a => a.FullName!.StartsWith("ApiConta.Infra"))
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
    typeof(ContaRepositoryProfile)
);

var app = builder.Build();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
