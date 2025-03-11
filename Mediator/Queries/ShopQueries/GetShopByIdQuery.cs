using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Queries.ShopQueries
{
    public class GetShopByIdQuery : IRequest<Shop>
    {
        public int ShopId { get; set; }
    }
}
