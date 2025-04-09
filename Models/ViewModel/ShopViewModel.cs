using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;

namespace OnlineShop.Models.ViewModel
{
    public class ShopViewModel
    {
        public Shop Shop { get; set; }
        public PaginatedList<User> Users { get; set; }
        public string? UserSearchTerm { get; set; }
        public PaginatedList<Product> Products { get; set; }
        public string? ProductSearchTerm { get; set; }
    }
}
