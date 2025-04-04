using MediatR;
using OnlineShop.Mediator.Search.SearchQueries;
using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Search.SearchHandlers
{
    public class GetShopsWithPaginationQueryHandler : IRequestHandler<GetShopsWithPaginationQuery,PaginatedList<Shop>>
    {
        private readonly IShopRepository _shopRepository;

        public GetShopsWithPaginationQueryHandler(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<PaginatedList<Shop>> Handle(GetShopsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var shops = await _shopRepository.GetShopsWithPagination(request.PageNumber, request.PageSize, request.ShopSearch);
            return shops;
        }

    }
}
