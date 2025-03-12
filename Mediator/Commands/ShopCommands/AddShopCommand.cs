using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Commands.ShopCommands
{
    public class AddShopCommand : IRequest<Shop>
    {
        public string Name { get; set; }
        public string? ManagerName { get; set; }
    }
}
