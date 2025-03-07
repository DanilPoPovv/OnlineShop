using OnlineShop.Models.ViewModel;
using MediatR;

namespace OnlineShop.Mediator.Search.SearchQueries
{
    public class SearchShopsAndUsersQuery : IRequest<SearchViewModel>
    {
        public string? Username { get; set; }
        public string? ShopName { get; set; }
    }
}
