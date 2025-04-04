//using MediatR;
//using OnlineShop.Models.POCO;
//using OnlineShop.Mediator.Queries.ShopQueries;
//using OnlineShop.Repositories;
//using OnlineShop.Repositories.Interfaces;
//using System.Runtime.CompilerServices;

//namespace OnlineShop.Mediator.QueryHandlers.ShopQueriesHandler
//{
//    public class GetAllShopByNameQueryHandler : IRequestHandler<GetAllShopsByNameQuery,List<Shop>>
//    {
//        private readonly IShopRepository _shopRepository;
//        public GetAllShopByNameQueryHandler(IShopRepository shopRepository)
//        {
//            _shopRepository = shopRepository;
//        }
//        public async Task<List<Shop>> Handle(GetAllShopsByNameQuery query, CancellationToken cancellationToken) 
//        {
//            var shops = await _shopRepository.GetAllShopByName(query.ShopName);
//            return shops;
//        }
//    }
//}
