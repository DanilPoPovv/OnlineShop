using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Queries.ShopQueries
{
    public class GetAllShopProductsQuery : IRequest<List<Product>>
    {
        public int shopId {  get; set; }
    }
}
