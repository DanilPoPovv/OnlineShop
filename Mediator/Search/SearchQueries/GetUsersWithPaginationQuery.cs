using MediatR;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Mediator.Queries.UserQueries;
using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;
using OnlineShop.Models.ViewModel;
using System.Reflection.Metadata.Ecma335;

namespace OnlineShop.Mediator.Search.SearchQueries
{
    public class GetUsersWithPaginationQuery : IRequest<PaginatedList<User>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? UserSearch { get; set; }
        public GetUsersWithPaginationQuery(int pageNumber, int pageSize,string? userSearch = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            UserSearch = userSearch;
        }
    }
}
