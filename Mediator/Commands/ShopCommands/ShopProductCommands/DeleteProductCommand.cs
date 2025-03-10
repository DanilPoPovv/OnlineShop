using MediatR;
using OnlineShop.Models;

namespace OnlineShop.Mediator.Commands.ShopCommands.ShopProductCommands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public string ProductName { get; set; }
        public string ShopName { get; set; }
    }
}
