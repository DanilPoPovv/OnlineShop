using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;

namespace OnlineShop.Repositories.Interfaces
{
    public interface IShopRepository : IRepository<Shop>
    {
        Task<PaginatedList<Product>> GetShopProducts(int shopId,int pageNumber,int pageSize, string? productSearch);
        Task<PaginatedList<User?>> GetShopUsers(int shopId, int pageNumber, int pageSize, string? userSearch);
        Task<PaginatedList<Shop>> GetShopsWithPagination(int pageNumber,int pageSize, string? shopSearch);
        Task<List<User>> GetAllShopEmployees(int shopId);
        Task<User> GetShopManagerByShopName(string shopName);
        Task<Shop> GetShopByName(string shopName);
        Task<Shop> GetShopByIdIncludeManager(int shopId);
    }
}
