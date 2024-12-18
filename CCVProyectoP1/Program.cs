﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CCVProyectoP1.Data;
using CCVProyectoP1.Models;

using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CCVProyectoP1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CCVProyectoP1Context") ?? throw new InvalidOperationException("Connection string 'CCVProyectoP1Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//tiempo de expiracion, autenticacion de cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Login/Index";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        option.AccessDeniedPath = "/Home/Privacy";
    });


//inyectar logica en todo el proyecto
builder.Services.AddScoped<Logica>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();    

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
