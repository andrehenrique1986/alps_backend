using ALPS.Application.AppServices.Interfaces;
using ALPS.Application.AppServices.Services;
using ALPS.Domain.Interfaces.Repository;
using ALPS.Domain.Interfaces.Services;
using ALPS.Domain.Services;
using ALPS.Infra.Data.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ALPS.API",
        Version = "v1"
    });
});

// Serviços da camada de aplicação
builder.Services.AddScoped<IAppUsuarioService, AppUsuarioService>();

// Serviços da camada de domínio
builder.Services.AddScoped<IUsuarioService, UsuarioService>();


// Repositórios da camada de infraestrutura
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ALPS.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
