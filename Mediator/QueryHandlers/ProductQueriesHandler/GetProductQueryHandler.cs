using MediatR;
using OnlineShop.Mediator.Queries.ProductQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.QueryHandlers.ProductQueriesHandler
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery,Product>
    {
        private readonly IRepository<Product> _repository;
        public GetProductQueryHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<Product> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(query.ProductId);
        }
    }
}
