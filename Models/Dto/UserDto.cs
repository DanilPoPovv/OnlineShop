using OnlineShop.Models.POCO;

namespace OnlineShop.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public UserRole Role { get; set; }
    }
}
