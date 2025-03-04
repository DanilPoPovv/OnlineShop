using MediatR;
using OnlineShop.Models;
using OnlineShop.Repositories.Interfaces;
using OnlineShop.Mediator.Commands.UserCommands;

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
                Role = UserRole.Seller,
                ShopId = request.ShopId,
            };

            await _userRepository.AddAsync(user);
            return user;
        }
    }
}
