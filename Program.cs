using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
using System.Reflection;
using APIFinancia.Infra;
using APIFinancia.Application.Behaviors;
using APIFinancia.Application.Commands;
using APIFinancia.Application.Handlers;
using APIFinancia.Application.Validators;
using APIFinancia.Infra.Extension;
using APIFinancia.Shared;
using System;
using APIFinancia.Repository;
using APIFinancia.Repository.Expense;

var builder = WebApplication.CreateBuilder(args);
ConformitySettings.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<ADOContext>();
// Configura��o do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionando MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Adicionando FluentValidation
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Configura��o dos pipelines
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidator();
// Configura��o do MVC
builder.Services.AddControllers();

// Configura��o de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();


app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"); 
    c.RoutePrefix = string.Empty; 
});


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
