using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Commands.ShopCommands
{
    public class AddSellerCommand : IRequest<User>
    {
        public int ShopId { get; set; }
        public string UserName { get; set; }
    }
}
