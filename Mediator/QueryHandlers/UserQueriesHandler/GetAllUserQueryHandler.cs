using MediatR;
using OnlineShop.Mediator.Queries.UserQueries;
using OnlineShop.Models;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.QueryHandlers.UserQueriesHandler
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        IRepository<User> _shopRepository;

        public GetAllUserQueryHandler(IRepository<User> repository)
        {
            _shopRepository = repository;
        }
        public async Task<List<User>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            return await _shopRepository.GetAllAsync();
        }
    }
}
