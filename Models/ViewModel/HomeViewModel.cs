using OnlineShop.Models.POCO;

namespace OnlineShop.Models.ViewModel
{
    public class HomeViewModel
    {
        public List<User> Users { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
