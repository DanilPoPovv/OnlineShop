using MediatR;
using OnlineShop.Exceptions.ShopExceptions;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.QueryHandlers.ShopQueriesHandler
{
    public class GetShopByNameQueryHandler : IRequestHandler<GetShopByNameQuery,Shop>
    {
        IShopRepository _shopRepository;
        public GetShopByNameQueryHandler(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        public async Task<Shop> Handle(GetShopByNameQuery query, CancellationToken cancellationToken)
        {
            var shop = await _shopRepository.GetShopByName(query.ShopName);
            if (shop == null)
            {
                throw new ShopNotFoundException($"Shop with name {query.ShopName} not found");
            }
            return shop;
        }
    }
}
