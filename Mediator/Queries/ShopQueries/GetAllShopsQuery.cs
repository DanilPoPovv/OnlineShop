using MediatR;
using OnlineShop.Models;

namespace OnlineShop.Mediator.Queries.ShopQueries
{
    public class GetAllShopsQuery : IRequest<List<Shop>>
    {
    }
}
