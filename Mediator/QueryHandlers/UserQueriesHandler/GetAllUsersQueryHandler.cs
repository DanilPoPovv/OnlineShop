using MediatR;
using OnlineShop.Mediator.Queries.UserQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.QueryHandlers.UserQueriesHandler
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        IRepository<User> _shopRepository;

        public GetAllUsersQueryHandler(IRepository<User> repository)
        {
            _shopRepository = repository;
        }
        public async Task<List<User>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            return await _shopRepository.GetAllAsync();
        }
    }
}
