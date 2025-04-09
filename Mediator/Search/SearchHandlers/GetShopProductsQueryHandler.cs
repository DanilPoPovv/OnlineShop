using MediatR;
using OnlineShop.Mediator.Search.SearchQueries;
using OnlineShop.Models.Dto;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Search.SearchHandlers
{
    public class GetShopProductsQueryHandler : IRequestHandler<GetShopProductsQuery,PaginatedList<Product>>
    {
        private readonly IShopRepository _shopRepository;
        public GetShopProductsQueryHandler(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        public async Task<PaginatedList<Product>> Handle(GetShopProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _shopRepository.GetShopProducts(query.ShopId, query.PageNumber, query.PageSize, query.ProductSearch);
            return products;
        }
    }
}
