using MediatR;
using OnlineShop.Models;

namespace OnlineShop.Mediator.Queries.ShopQueries
{
    public class GetAllShopEmployeeQuery : IRequest<List<User>>
    {
        public string shopName;
    }
}
