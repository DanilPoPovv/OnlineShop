using MediatR;
using OnlineShop.Models;

namespace OnlineShop.Mediator.Commands.ShopCommands
{
    public class AddShopCommand : IRequest<Shop>
    {
        public string Name { get; set; }
        public int? ManagerId { get; set; }
    }
}
