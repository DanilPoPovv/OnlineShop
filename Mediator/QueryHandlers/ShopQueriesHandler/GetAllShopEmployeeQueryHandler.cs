using MediatR;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.QueryHandlers.ShopQueriesHandler
{
    public class GetAllShopEmployeeQueryHandler : IRequestHandler<GetAllShopEmployeeQuery,List<User>>
    {
        IShopRepository _shopRepository;

        public GetAllShopEmployeeQueryHandler(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<List<User>> Handle(GetAllShopEmployeeQuery query,CancellationToken cancellationToken) 
        {
            return await _shopRepository.GetAllShopEmployees(query.shopId);
        }
    }
}
