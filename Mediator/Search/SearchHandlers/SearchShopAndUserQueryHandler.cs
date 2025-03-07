using MediatR;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Mediator.Queries.UserQueries;
using OnlineShop.Mediator.Search.SearchQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Models.ViewModel;

namespace OnlineShop.Mediator.Search.SearchHandlers
{
    public class SearchShopAndUserQueryHandler : IRequestHandler<SearchShopsAndUsersQuery, SearchViewModel>
    {
        private readonly IMediator _mediator;

        public SearchShopAndUserQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<SearchViewModel> Handle(SearchShopsAndUsersQuery query, CancellationToken cancellationToken)
        {
            List<User> users = new();
            List<Shop> shops = new();

            if (!string.IsNullOrWhiteSpace(query.Username))
            {
                users = await _mediator.Send(new GetAllUsersByNameQuery { Username = query.Username }, cancellationToken);
            }

            if (!string.IsNullOrWhiteSpace(query.ShopName))
            {
                shops = await _mediator.Send(new GetAllShopsByNameQuery { ShopName = query.ShopName }, cancellationToken);
            }

            return new SearchViewModel
            {
                ShopSearchTerm = query.ShopName,
                UserSearchTerm = query.Username,
                Users = users,   
                Shops = shops
            };
        }
    }
}
