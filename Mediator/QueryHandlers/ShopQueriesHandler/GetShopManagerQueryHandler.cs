using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.QueryHandlers.ShopQueriesHandler
{
    public class GetShopManagerQueryHandler
    {
        IShopRepository _shopRepository;

        public GetShopManagerQueryHandler(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        public async Task<User> Handle(GetShopManagerQuery query, CancellationToken cancellationToken) 
        {
            return await _shopRepository.GetShopManagerByShopName(query.shopName);
        }
    }
}
