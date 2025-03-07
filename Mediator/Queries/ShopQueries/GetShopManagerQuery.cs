using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Queries.ShopQueries
{
    public class GetShopManagerQuery : IRequest<User>
    {
        public string shopName;
    }
}
