using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;

namespace OnlineShop.Models.ViewModel
{
    public class SearchViewModel
    {
        public string? UserSearchTerm { get; set; }
        public string? ShopSearchTerm { get; set; }
        public PaginatedList<User> Users { get; set; }
        public PaginatedList<Shop> Shops { get; set; }
        public int UsersPageNumber { get; set; }
        public int UsersTotalPages { get; set; }    
        public int ShopsPageNumber { get; set; }
        public int ShopsTotalPages { get; set; }
    }
}
