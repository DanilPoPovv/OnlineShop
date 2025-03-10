using MediatR;
using OnlineShop.Repositories.Interfaces;
using OnlineShop.Mediator.Commands.UserCommands;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Handlers.UserHandler
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IRepository<User> _userRepository;
        public AddUserCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Password = request.Password,
                Role = request.Role,
                Shop = request.shop,
            };

            await _userRepository.AddAsync(user);
            return user;
        }
    }
}
