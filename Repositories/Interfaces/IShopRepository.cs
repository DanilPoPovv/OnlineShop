using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;

namespace OnlineShop.Repositories.Interfaces
{
    public interface IShopRepository : IRepository<Shop>
    {
        Task<List<Product>> GetAllShopProducts(int shopId);
        Task<PaginatedList<Shop>> GetShopsWithPagination(int pageNumber,int pageSize, string? shopSearch);
        Task<List<User>> GetAllShopEmployees(int shopId);
        Task<User> GetShopManagerByShopName(string shopName);
        Task<Shop> GetShopByName(string shopName);
        Task<Shop> GetShopByIdIncludeManager(int shopId);
    }
}
