using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.DatabaseContext;
using OnlineShop.Models.Dto;
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
        public async Task<PaginatedList<Shop>> GetShopsWithPagination(int pageNumber, int pageSize, string? shopSearch)
        {
            var query = _dbSet.AsQueryable();
            if (!string.IsNullOrEmpty(shopSearch))
            {
                query = query.Where(s => s.Name.ToLower().Contains(shopSearch.ToLower()));
            }

            var count = await _context.Shops.CountAsync();
            var shops = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedList<Shop>(shops, count, pageNumber, pageSize);
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
        public async Task<Shop> GetShopByIdIncludeManager(int shopId) 
        {
            var shop = await _dbSet.Include(s => s.Manager).Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == shopId);
            return shop!;
        }
    }
}
