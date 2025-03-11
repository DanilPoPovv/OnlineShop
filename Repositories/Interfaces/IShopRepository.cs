using OnlineShop.Models.POCO;

namespace OnlineShop.Repositories.Interfaces
{
    public interface IShopRepository : IRepository<Shop>
    {
        Task<List<Product>> GetAllShopProducts(int shopId);
        Task<List<Shop>> GetAllShopByName(string shopName);
        Task<List<User>> GetAllShopEmployees(int shopId);
        Task<User> GetShopManagerByShopName(string shopName);
        Task<Shop> GetShopByName(string shopName);
        Task<bool> DeleteShopProduct(Shop shop,string shopName);
    }
}
