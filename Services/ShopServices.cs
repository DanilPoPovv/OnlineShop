using Microsoft.EntityFrameworkCore;
using OnlineShop.DatabaseContext;

namespace OnlineShop.Services
{
    public class ShopServices
    {
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("DefaultConnection"));

            services.AddControllersWithViews();
        }
        
    }
}
