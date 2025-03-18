using MediatR;
using OnlineShop.Mediator.Queries.UserQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.QueryHandlers.UserQueriesHandler
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery,User>
    {
        IRepository<User> _userRepository;

        public GetUserQueryHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByIdAsync(query.Id);

        }
    }
}
