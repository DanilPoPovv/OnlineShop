using Microsoft.EntityFrameworkCore;
using OnlineShop.DatabaseContext;
using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<string> GetUserShopByUserName(string userName)
        {
            var user = await _dbSet.Where(s => s.Name == userName).Include(s => s.Shop).FirstOrDefaultAsync();

            if (user == null || user.Shop == null) 
            {
                return null;
            }

            return user.Shop.Name;
        }
        public async Task<string> GetUserRoleByUserName(string userName) 
        {
            var user = await _dbSet.Where(s => s.Name == userName).Include(s => s.Role).FirstOrDefaultAsync();

            if (user == null) 
            {
                return null;
            }
            return user.Role.ToString();
        }


    }
}
