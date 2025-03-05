using OnlineShop.DatabaseContext;
using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base (context){ }

        public async Task<>
    }
}
