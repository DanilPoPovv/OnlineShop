using MediatR;

namespace OnlineShop.Mediator.Commands.ShopCommands
{
    public class DeleteShopByShopNameCommand : IRequest<bool>
    {
        public string ShopName { get; set; }
    }
}
