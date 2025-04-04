using MediatR;
using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Search.SearchQueries
{
    public class GetShopProductsQuery : IRequest<PaginatedList<Product>>
    {
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
    }
}
