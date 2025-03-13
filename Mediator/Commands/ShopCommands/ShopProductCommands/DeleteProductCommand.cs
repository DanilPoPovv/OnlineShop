using MediatR;
using OnlineShop.Models;

namespace OnlineShop.Mediator.Commands.ShopCommands.ShopProductCommands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
    }
}
