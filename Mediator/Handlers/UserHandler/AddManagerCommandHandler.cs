using MediatR;
using OnlineShop.Mediator.Commands.UserCommands;
using OnlineShop.Models;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.UserHandler
{
    public class AddManagerCommandHandler : IRequestHandler<AddManagerCommand, User>
    {
        IRepository<User> _userRepository;

        public AddManagerCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(AddManagerCommand command, CancellationToken cancellationToken)
        {
            var manager = new User
            {
                Name = command.Name,
                Password = command.Password,
                Role = UserRole.Manager,
                ManagedShopId = command.ManagedShopId,
            };

            await _userRepository.AddAsync(manager);
            return manager;
        }

    }
}
