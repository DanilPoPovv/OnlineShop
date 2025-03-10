using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Commands.ShopCommands.ShopProductCommands
{
    public class UpdateProductCommand : IRequest<Product?>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
    }
}
