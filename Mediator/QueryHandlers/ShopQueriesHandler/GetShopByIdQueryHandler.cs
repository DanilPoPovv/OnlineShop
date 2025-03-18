using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.QueryHandlers.ShopQueriesHandler
{
    public class GetShopByIdQueryHandler : IRequestHandler<GetShopByIdQuery,Shop>
    {
        IRepository<Shop> _shopRepository;
        public GetShopByIdQueryHandler(IRepository<Shop> shopRepository)
        {
            _shopRepository = shopRepository;
        }
        public async Task<Shop> Handle(GetShopByIdQuery request, CancellationToken cancellationToken)
        {
            var shop = await _shopRepository.GetByIdAsync(request.ShopId);
            return shop;
        }  
    }
}
