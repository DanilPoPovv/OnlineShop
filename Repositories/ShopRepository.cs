using Microsoft.EntityFrameworkCore;
using OnlineShop.DatabaseContext;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Repositories
{
    public class ShopRepository : Repository<Shop>, IShopRepository
    {
        public ShopRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Product>> GetAllShopProductsByShopName(string shopName) 
        {
            return await _dbSet.Where(s => s.Name == shopName).SelectMany(s => s.Products!).ToListAsync();
        }
        public async Task<List<Shop>> GetAllShopByName(string shopName) 
        {
            return await _dbSet.Where(s => s.Name.ToLower().Contains(shopName.ToLower())).ToListAsync();
        }
        public async Task<List<User>> GetAllShopEmployeesByShopName(string shopName) 
        {
            return await _dbSet.Where(s => s.Name == shopName).SelectMany(u => u.Employees!).ToListAsync();
        }
        public async Task<User> GetShopManagerByShopName(string shopName) 
        {
            var shop = await _dbSet.Include(s => s.Manager).FirstOrDefaultAsync(s => s.Name == shopName);

            return shop?.Manager;
        }
        public async Task<Shop> GetShopById(int shopId) 
        {
            var shop = await _dbSet.Include(s => s.Manager).Include(s => s.Employees).Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == shopId);
            return shop;
        }
    }
}
