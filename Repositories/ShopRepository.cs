using OnlineShop.DatabaseContext;
using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public class ShopRepository : Repository<Shop>
    {
        public ShopRepository(ApplicationDbContext context) : base(context) { }
    }
}
