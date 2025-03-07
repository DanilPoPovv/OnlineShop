using OnlineShop.DatabaseContext;
using OnlineShop.Models.POCO;

namespace OnlineShop.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base (context){ }
    }
}
