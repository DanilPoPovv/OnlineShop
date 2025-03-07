using MediatR;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.QueryHandlers.ShopQueriesHandler
{
    public class GetShopByIdQueryHandler : IRequestHandler<GetShopByIdQuery,Shop>
    {
        IShopRepository _repository;

        public GetShopByIdQueryHandler(IShopRepository repository)
        {
            _repository = repository;
        }

        public async Task<Shop> Handle(GetShopByIdQuery request, CancellationToken cancellationToken)
        {
            var shop = await _repository.GetShopById(request.Id);
            return shop;
        }
    }
}
