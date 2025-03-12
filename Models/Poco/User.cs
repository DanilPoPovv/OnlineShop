using System.Text.Json.Serialization;

namespace OnlineShop.Models.POCO
{
    public enum UserRole
    {
        Admin,
        Manager,
        Seller
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public UserRole Role { get; set; }
        public int? ShopId { get; set; }
        public Shop? Shop { get; set; }
        public int? ManagedShopId { get; set; }
        [JsonIgnore]
        public Shop? ManagedShop { get; set; }
    }
}
