using OnlineShop.Models.POCO;

namespace OnlineShop.Repositories.Interfaces
{
    public interface IShopRepository : IRepository<Shop>
    {
        Task<List<Product>> GetAllShopProductsByShopName(string shopName);
        Task<List<Shop>> GetAllShopByName(string shopName);
        Task<List<User>> GetAllShopEmployeesByShopName(string shopName);
        Task<User> GetShopManagerByShopName(string shopName);
        Task<Shop> GetShopByName(string shopName);
        Task<bool> DeleteShopProduct(Shop shop,string shopName);
    }
}
