using MediatR;
using OnlineShop.Mediator.Queries.UserQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;
namespace OnlineShop.Mediator.QueryHandlers.UserQueriesHandler
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery,User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByUserNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(GetUserByUserNameQuery query,CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUserName(query.UserName);
            return user;
        }
    }
}
