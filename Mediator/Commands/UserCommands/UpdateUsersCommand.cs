using MediatR;
using OnlineShop.Models;

namespace OnlineShop.Mediator.Commands.UserCommands
{
    public class UpdateUsersCommand : IRequest<User?>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Password { get; set; }
        public UserRole? Role { get; set; }
        public int? ShopId { get; set; }
    }
}
