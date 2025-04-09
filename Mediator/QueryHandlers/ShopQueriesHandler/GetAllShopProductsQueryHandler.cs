//using MediatR;
//using OnlineShop.Mediator.Queries.ShopQueries;
//using OnlineShop.Mediator.Search.SearchQueries;
//using OnlineShop.Models.POCO;
//using OnlineShop.Repositories;
//using OnlineShop.Repositories.Interfaces;

//namespace OnlineShop.Mediator.QueryHandlers.ShopQueriesHandler
//{
//    public class GetAllShopProductsQueryHandler : IRequestHandler<GetShopProductsQuery,List<Product>>
//    {
//        IShopRepository _productRepository;
//        public GetAllShopProductsQueryHandler(IShopRepository productRepository)
//        {
//            _productRepository = productRepository;
//        }
//        public async Task<List<Product>> Handle(GetShopProductsQuery query,CancellationToken cancellationToken) 
//        {
//            return await _productRepository.GetShopProducts(query.ShopId, query.PageNumber, query.PageSize, query.ProductSearch);
//        }
//    }
//}
