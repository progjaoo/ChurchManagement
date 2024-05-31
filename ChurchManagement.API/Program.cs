using ChurchManagement.Application.Commands.Cargos.Create;
using ChurchManagement.Application.Commands.Departamentos.Create;
using ChurchManagement.Application.Commands.Membros.CreateMember;
using ChurchManagement.Application.Commands.Posts.Create;
using ChurchManagement.Application.Queries.Membros.GetAll;
using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using ChurchManagement.Infrastructure.Authentication;
using ChurchManagement.Infrastructure.Persistence.Repositorios;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region JWT BEARER CONFIG
//CONFIGURAÇÃO DO TOKEN JWT BEARER
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChurchManagement.API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando o esquema Bearer."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
#endregion 

#region CONFIGURAÇÕES
//config banco de dados connection string
builder.Services.AddDbContext<ChurchManagementContext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("ChurchManagementDB")));

//register DI
builder.Services.AddScoped<IMembroRepository, MembroRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICargoRepository, CargoRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<ITesourariaRepository, TesourariaRepository>();
builder.Services.AddScoped<ITransacaoTesourariaRepository, TransacaoTesourariaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

//autenticacao DI
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<IPDFGenerator, PDFGenerator>(); // Registrar o serviço de PDF




//register mediator
builder.Services.AddMediatR(typeof(GetAllMembrosQuery));
builder.Services.AddMediatR(typeof(CreateMembroCommand));
builder.Services.AddMediatR(typeof(CreateDepartamentoCommand));
builder.Services.AddMediatR(typeof(CreateCargoCommand));
builder.Services.AddMediatR(typeof(CreatePostCommand));

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
