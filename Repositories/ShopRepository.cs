using Microsoft.EntityFrameworkCore;
using OnlineShop.DatabaseContext;
using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public class ShopRepository : Repository<Shop>
    {
        public ShopRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Product>> GetAllShopProductsByShopName(string shopName) 
        {
            return await _dbSet.Where(s => s.Name == shopName).SelectMany(s => s.Products!).ToListAsync();
        }
        public async Task<List<User>> GetAllShopEmployeesByShopName(string shopName) 
        {
            return await _dbSet.Where(s => s.Name == shopName).SelectMany(u => u.Employees!).ToListAsync();
        }
        public async Task<User> GetShopManagerByShopName(string shopName) 
        {
            return await _dbSet.Where(s => s.Name == shopName).Select(m => m.Manager).FirstOrDefaultAsync();
        }
    }
}
