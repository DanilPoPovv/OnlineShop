using MediatR;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Repositories.Interfaces;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.QueryHandlers.ShopQueriesHandler
{
    public class GetAllShopQueryHandler : IRequestHandler<GetAllShopsQuery, List<Shop>>
    {
        IRepository<Shop> _shopRepository;

        public GetAllShopQueryHandler(IRepository<Shop> repository)
        {
            _shopRepository = repository;
        }

        public async Task<List<Shop>> Handle(GetAllShopsQuery query, CancellationToken cancellationToken)
        {
            return await _shopRepository.GetAllAsync();
        }
    }
}
