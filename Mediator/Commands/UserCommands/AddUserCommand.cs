using MediatR;
using OnlineShop.Models.POCO;
namespace OnlineShop.Mediator.Commands.UserCommands
{
    public class AddUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string? ShopName  { get; set; }
        public UserRole Role { get; set; }
    }
}
