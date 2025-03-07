using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Queries.ShopQueries
{
    public class GetAllShopsQuery : IRequest<List<Shop>>
    {

    }
}
