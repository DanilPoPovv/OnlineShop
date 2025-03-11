using MediatR;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.QueryHandlers.ShopQueriesHandler
{
    public class GetAllShopProductsQueryHandler : IRequestHandler<GetAllShopProductsQuery,List<Product>>
    {
        IShopRepository _productRepository;
        public GetAllShopProductsQueryHandler(IShopRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> Handle(GetAllShopProductsQuery query,CancellationToken cancellationToken) 
        {
            return await _productRepository.GetAllShopProducts(query.shopId);
        }
    }
}
