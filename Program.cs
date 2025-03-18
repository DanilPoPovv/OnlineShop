using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Mediator.Commands.ShopCommands;
using NLog;
using NLog.Web;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;
using OnlineShop.Repositories;
using Microsoft.OpenApi.Models;
using OnlineShop.Data.DatabaseContext;


var logger = LogManager.Setup().LoadConfigurationFromFile(Path.Combine(AppContext.BaseDirectory, "nlog.Config")).GetCurrentClassLogger();
logger.Info("Info");
logger.Info("Application started");
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Регистрация репозиториев
    builder.Services.AddScoped<IRepository<User>, Repository<User>>();
    builder.Services.AddScoped<IRepository<Shop>, Repository<Shop>>();
    builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
    builder.Services.AddScoped<IShopRepository, ShopRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();


    // Настройка аутентификации (Cookies)
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Authentication/Login";
            options.AccessDeniedPath = "/Home/AccessDenied";
        });

    // Подключение MediatR
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddShopCommand).Assembly));

    // Подключение Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineShop API", Version = "v1" });
    });

    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    if (app.Environment.IsDevelopment()) // Включаем Swagger только в режиме разработки
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineShop API v1");
        });
    }
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }

    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.MapControllers();

    // Настройка маршрутов
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapControllerRoute(
        name: "auth",
        pattern: "{controller=Authentication}/{action=Login}/{id?}");

    app.Run();
}
catch(Exception ex)
{
    logger.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    LogManager.Shutdown();
}
