using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Persistence.DataContext;
using Persistence.Http;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigurePersistenceApp(builder.Configuration); //<== Pegando o bloco construtor de projeto 

builder.Services.ConfigureApplicationApp(); //<== Pegando o bloco construtor de projeto 

builder.Services.AddScoped<Application.ApiExternalCases.ApiExternalCases>();
//builder.Services.AddDbContext<FuelPointerDbContext>(opt => opt.UseSqlServer("ConnectionStrings"));
builder.Services.AddIdentity<User, IdentityRole>()
           .AddEntityFrameworkStores<FuelPointerDbContext>()
           .AddDefaultTokenProviders();


builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
