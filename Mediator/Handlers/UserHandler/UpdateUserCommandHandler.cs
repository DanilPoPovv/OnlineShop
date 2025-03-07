using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineShop.Mediator.Commands.UserCommands;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.UserHandler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUsersCommand,User?>   
    {
        IRepository<User> _userRepository;
        public UpdateUserCommandHandler(IRepository<User> repository)
        {
            _userRepository = repository;
        }
        public async Task<User> Handle(UpdateUsersCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId);
            if (user == null)
            {
                return null!;
            }
            user.Name = command.Name ?? user.Name;
            user.Password = command.Password ?? user.Password;
            user.Role = command.Role ?? user.Role;
            user.ShopId = command.ShopId ?? user.ShopId;

            await _userRepository.UpdateAsync(user);
            return user;
        }
        
    }
}
