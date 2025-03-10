﻿using Microsoft.EntityFrameworkCore;
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
    }
}
