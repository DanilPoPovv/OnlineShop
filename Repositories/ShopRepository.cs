using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.DatabaseContext;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Repositories
{
    public class ShopRepository : Repository<Shop>, IShopRepository
    {
        public ShopRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Product>> GetAllShopProducts(int shopId) 
        {
            return await _dbSet.Where(s => s.Id == shopId).SelectMany(s => s.Products!).ToListAsync();
        }
        public async Task<List<Shop>> GetAllShopByName(string shopName) 
        {
            return await _dbSet.Where(s => s.Name.ToLower().Contains(shopName.ToLower())).Include(s => s.Manager).ToListAsync();
        }
        public async Task<List<User>> GetAllShopEmployees(int shopId) 
        {
            return await _dbSet.Where(s => s.Id == shopId).SelectMany(u => u.Employees!).ToListAsync();
        }
        public async Task<User> GetShopManagerByShopName(string shopName) 
        {
            var shop = await _dbSet.Include(s => s.Manager).FirstOrDefaultAsync(s => s.Name == shopName);

            return shop?.Manager;
        }
        public async Task<Shop> GetShopByName(string shopName) 
        {
            var shop = await _dbSet.Include(s => s.Products).FirstOrDefaultAsync(s => s.Name == shopName);
            return shop!;
        }
/// TODO нужно подправить удаление и сделать его через метод Delete базового репозитория
        public async Task<bool> DeleteShopProduct(Shop shop,string productName) 
        {
            var product = shop.Products.FirstOrDefault(s => s.Name==productName);
            if (product == null)
            {
                return false;
            }
            shop.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Shop> GetShopByIdIncludeManager(int shopId) 
        {
            var shop = await _dbSet.Include(s => s.Manager).Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == shopId);
            return shop!;
        }
    }
}
