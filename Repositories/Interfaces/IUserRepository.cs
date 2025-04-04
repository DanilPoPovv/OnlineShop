using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;

namespace OnlineShop.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUserName(string userName);
        Task<List<User>> GetAllUsersByName(string userName);
        Task<User> GetUserByIdIncludeShop(int id);
        Task<PaginatedList<User?>> GetUsersWithPagination(int pageNumber, int pageSize, string? userSearch);
    }
}
