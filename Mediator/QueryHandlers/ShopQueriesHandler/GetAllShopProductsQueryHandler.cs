using MediatR;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Models;
using OnlineShop.Repositories;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.QueryHandlers.ShopQueriesHandler
{
    public class GetAllShopProductsQueryHandler : IRequestHandler<GetAllShopProductsByShopNameQuery,List<Product>>
    {
        ShopRepository _productRepository;
        public GetAllShopProductsQueryHandler(ShopRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> Handle(GetAllShopProductsByShopNameQuery query,CancellationToken cancellationToken) 
        {
            return await _productRepository.GetAllShopProductsByShopName(query.ShopName);
        }
    }
}
