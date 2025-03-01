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
using APIFinancia.Infra.Repository;
using APIFinancia.Infra.Extension;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Configuração do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionando MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Adicionando FluentValidation
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Configuração dos pipelines
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidator();
// Configuração do MVC
builder.Services.AddControllers();

// Configuração de Swagger
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
