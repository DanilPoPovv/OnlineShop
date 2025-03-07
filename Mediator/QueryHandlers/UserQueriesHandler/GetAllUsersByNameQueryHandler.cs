using MediatR;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;
using OnlineShop.Mediator.Queries;
using System.Security.Cryptography;
using OnlineShop.Mediator.Queries.UserQueries;

namespace OnlineShop.Mediator.QueryHandlers.UserQueriesHandler
{
    public class GetAllUsersByNameQueryHandler : IRequestHandler<GetAllUsersByNameQuery, List<User>>
    {
        IUserRepository _repository;

        public GetAllUsersByNameQueryHandler(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public async Task<List<User>> Handle(GetAllUsersByNameQuery query, CancellationToken cancellationToken) 
        {
            var users = await _repository.GetAllUsersByName(query.Username);
            return users;
        }
    }
}
