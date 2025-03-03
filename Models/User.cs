namespace OnlineShop.Models
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
        public int Name { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
