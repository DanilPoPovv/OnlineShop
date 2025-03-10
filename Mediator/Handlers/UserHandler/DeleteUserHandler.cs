using MediatR;
using OnlineShop.Mediator.Commands.UserCommands;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.UserHandler
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand,bool>
    {
        IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public async Task<bool> Handle(DeleteUserCommand command,CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUserName(command.UserName);
            if (user == null)
            {
                return false;
            }
            await _userRepository.DeleteAsync(user.Id);
            return true;
        }
    }
}
