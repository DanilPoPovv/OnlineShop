using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Queries.ShopQueries
{
    public class GetShopByNameQuery : IRequest<Shop>
    {
        public string ShopName { get; set; }
    }
}
