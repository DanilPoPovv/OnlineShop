using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Queries.ShopQueries
{
    public class GetAllShopsByNameQuery : IRequest<List<Shop>>
    {
        public string ShopName { get; set; }
    }
}
