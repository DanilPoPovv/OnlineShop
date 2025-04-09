using MediatR;
using OnlineShop.Mediator.Search.SearchQueries;
using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Search.SearchHandlers
{
    public class GetShopUsersQueryHandler : IRequestHandler<GetShopUsersQuery,PaginatedList<User>>
    {
        private readonly IShopRepository _shopRepository;
        public GetShopUsersQueryHandler(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<PaginatedList<User>> Handle(GetShopUsersQuery query,CancellationToken cancellationToken)
        {
            var users = await _shopRepository.GetShopUsers(query.ShopId, query.PageNumber, query.PageSize, query.UserSearch);

            return users;
        }
    }
}
