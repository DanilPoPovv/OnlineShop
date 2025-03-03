namespace OnlineShop.Models
{
    enum UserRole 
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
        public int MyProperty { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
