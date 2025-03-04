using MediatR;
using OnlineShop.Models;

namespace OnlineShop.Mediator.Commands.ProductCommands
{
    public class AddProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int ShopId { get; set; }
    }
}
