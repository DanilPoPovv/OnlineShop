﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.DatabaseContext;
using OnlineShop.Mediator.Authentication.AuthQuery;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Repositories
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }


        public async Task<User> GetUserByUserName(string username) 
        { 
            var user = await _dbSet.FirstOrDefaultAsync(s => s.Name == username);
            return user;
        }
        public async Task<List<User>> GetAllUsersByName(string username) 
        {
            var users = await _dbSet.Where(u => u.Name.ToLower().Contains(username.ToLower())).
                Include(u => u.Shop).
                ToListAsync();
            return users;
        }
        public async Task<User> GetUserByIdIncludeShop(int id)
        {
            var user = await _dbSet.Include(u => u.Shop).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}
