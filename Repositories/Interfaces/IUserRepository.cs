using OnlineShop.Models.POCO;

namespace OnlineShop.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<string> GetUserRoleByUserName(string userName);
        Task<string> GetUserShopByUserName(string userName);
        Task<User> GetUserByUserName(string userName);

        Task<List<User>> GetAllUsersByName(string userName);
        Task<User> GetUserByIdIncludeShop(int id);
    }
}
