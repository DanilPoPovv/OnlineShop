using MediatR;
using OnlineShop.Exceptions.UserExceptions;
using OnlineShop.Mediator.Commands.ShopCommands;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.ShopHandler
{
    public class AddSellerCommandHandler : IRequestHandler<AddSellerCommand,User> 
    {
        IUserRepository _userRepository;
        public AddSellerCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(AddSellerCommand command, CancellationToken cancellationToken) 
        { 
            var user = await _userRepository.GetUserByUserName(command.UserName);
            if (user == null)
            {
                throw new UserNotFoundException($"Seller with name {command.UserName} was not found");
            }
            if (user.ShopId == command.ShopId || (user.ShopId != null && user.ManagedShopId != null))
            {
                throw new Exception("User is already assigned to another shop");
            }
            user.ShopId = command.ShopId;
            await _userRepository.UpdateAsync(user);
            return user;
        }
    }
}
