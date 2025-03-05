using OnlineShop.DatabaseContext;
using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

    }
}
