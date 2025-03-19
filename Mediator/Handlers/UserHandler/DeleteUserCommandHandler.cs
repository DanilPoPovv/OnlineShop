using MediatR;
using OnlineShop.Exceptions.UserExceptions;
using OnlineShop.Mediator.Commands.UserCommands;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.UserHandler
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,bool>
    {
        IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public async Task<bool> Handle(DeleteUserCommand command,CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUserName(command.UserName);
            if (user == null)
            {
                throw new UserNotFoundException($"User not found with name {command.UserName} was not found");
            }
            await _userRepository.DeleteAsync(user.Id);
            return true;
        }
    }
}
