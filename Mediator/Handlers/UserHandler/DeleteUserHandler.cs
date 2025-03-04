using MediatR;
using OnlineShop.Mediator.Commands.UserCommands;
using OnlineShop.Models;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.UserHandler
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand,bool>
    {
        IRepository<User> _userRepository;
        public DeleteUserHandler(IRepository<User> repository)
        {
            _userRepository = repository;
        }
        public async Task<bool> Handle(DeleteUserCommand command,CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId);
            if (user == null)
            {
                return false;
            }
            await _userRepository.DeleteAsync(command.UserId);
            return true;
        }
    }
}
