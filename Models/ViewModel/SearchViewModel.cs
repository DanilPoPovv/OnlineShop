using OnlineShop.Models.POCO;

namespace OnlineShop.Models.ViewModel
{
    public class SearchViewModel
    {
        public string? UserSearchTerm { get; set; }
        public string? ShopSearchTerm { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<Shop> Shops { get; set; } = new List<Shop>();
    }
}
