using MediatR;
using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Search.SearchQueries
{
    public class GetShopsWithPaginationQuery : IRequest<PaginatedList<Shop>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? ShopSearch { get; set; }
        public GetShopsWithPaginationQuery(int pageNumber, int pageSize,string? shopSearch = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            ShopSearch = shopSearch;
        }
    }
}
