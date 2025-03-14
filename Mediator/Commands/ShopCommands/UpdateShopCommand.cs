using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Commands.ShopCommands
{
    public class UpdateShopCommand : IRequest<Shop?>
    {
        public int ShopId { get; set; }
        public string? ShopName { get; set; }
        public string? ManagerName { get; set; }
    }
}
