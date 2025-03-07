using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Commands.UserCommands
{
    public class AddManagerCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int ManagedShopId { get; set; }
    }
}
