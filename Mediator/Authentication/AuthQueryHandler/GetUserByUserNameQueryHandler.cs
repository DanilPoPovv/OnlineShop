using MediatR;
using OnlineShop.Mediator.Authentication.AuthQuery;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Authentication.AuthQueryHandler
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameAuthQuery,User>
    {
        IUserRepository _userRepository;
        public GetUserByUserNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(GetUserByUserNameAuthQuery request, CancellationToken cancellationToken) 
        {
            var user = await _userRepository.GetUserByUserName(request.Username);
            return user;
        }

    }
}
