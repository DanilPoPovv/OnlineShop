using MediatR;
using OnlineShop.Models;

namespace OnlineShop.Mediator.Commands.ProductCommands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
    }
}
