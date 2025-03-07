using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DatabaseContext;
using OnlineShop.Mediator.Commands.ShopCommands;
using MediatR;
using System.Reflection;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;
using OnlineShop.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Подключение к БД
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<Shop>, Repository<Shop>>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>(); // <--- ЭТО ДЛЯ ТОВАРОВ
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>(); // <--- ДЛЯ АУТЕНТИФИКАЦИИ

// Подключаем систему аутентификации через Cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Authtentication/Login";
        options.AccessDeniedPath = "/Home/AccessDenied";
    });

builder.Services.AddAuthorization();

// Подключаем MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddShopCommand).Assembly));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "auth",
    pattern: "Authentication/{action=Login}/{id?}");
app.Run();
