using CinemaApp.Core.Entities;
using CinemaApp.Data.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(x => { x.UseSqlServer(builder.Configuration.GetConnectionString("Default")); });


builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequiredUniqueChars = 2;
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequiredLength = 8;

    opt.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
