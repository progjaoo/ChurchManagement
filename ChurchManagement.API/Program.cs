using ChurchManagement.Application.Commands.Membros.CreateMember;
using ChurchManagement.Application.Queries.Membros.GetAll;
using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using ChurchManagement.Infrastructure.Persistence.Repositorios;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region CONFIGURAÇÕES
//config banco de dados connection string
builder.Services.AddDbContext<ChurchManagementContext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("ChurchManagementDB")));

//register DI
builder.Services.AddScoped<IMembroRepository, MembroRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICargoRepository, CargoRepository>();

//register mediator
builder.Services.AddMediatR(typeof(GetAllMembrosQuery));
builder.Services.AddMediatR(typeof(CreateMembroCommand));

#endregion
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
