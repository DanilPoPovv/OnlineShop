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

        public async Task<PaginatedList<Product>> GetShopProducts(int shopId, int pageNumber, int pageSize, string? productSearch)
        {
            var query = _dbSet
                .Where(s => s.Id == shopId) // Фильтрация по магазину
                .SelectMany(s => s.Products) // Разворачиваем коллекцию товаров
                .AsQueryable();

            if (!string.IsNullOrEmpty(productSearch))
            {
                query = query.Where(p => p.Name.ToLower().Contains(productSearch.ToLower()));
            }

            var totalCount = await query.CountAsync(); // Общее количество отфильтрованных товаров

            var products = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            Console.WriteLine($"Total products: {query.Count()}");

            return new PaginatedList<Product>(products, totalCount, pageNumber, pageSize);
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
        public async Task<PaginatedList<User?>> GetShopUsers(int shopId, int pageNumber, int pageSize, string? userSearch)
        {
            var query = _dbSet
            .Where(s => s.Id == shopId) // Фильтрация по магазину
            .SelectMany(s => s.Employees) // Разворачиваем коллекцию товаров
            .AsQueryable();

            if (!string.IsNullOrEmpty(userSearch))
            {
                query = query.Where(u => u.Name.ToLower().Contains(userSearch.ToLower()));
            }
            var totalCount = await query.CountAsync();

            var users = await query.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();
            return new PaginatedList<User?>(users, totalCount, pageNumber, pageSize);
        }
    }
}
