using MediatR;

namespace OnlineShop.Mediator.Commands.ShopCommands
{
    public class DeleteShopCommand : IRequest<bool>
    {
        public int ShopId { get; set; }
    }
}
