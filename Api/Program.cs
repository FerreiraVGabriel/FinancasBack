using Api.Extensao;
using Infra.Context;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injeção de Dependencia
builder.Services.AddDependencyInjection();

//Conexão banco
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

//Permissões api
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.WithOrigins(["http://localhost:4200"]);
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
    policy.AllowCredentials();
    policy.SetIsOriginAllowed(_=>true);
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
