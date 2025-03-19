using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineShop.Exceptions.UserExceptions;
using OnlineShop.Mediator.Commands.UserCommands;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.UserHandler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUsersCommand,User?>   
    {
        IUserRepository _userRepository;
        IShopRepository _shopRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository,IShopRepository shopRepository)
        {
            _userRepository = userRepository;
            _shopRepository = shopRepository;
        }
        public async Task<User?> Handle(UpdateUsersCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdIncludeShop(command.UserId);
            if (user == null)
            {
                throw new UserNotFoundException($"User with id {command.UserId} was not found");
            }

            bool isUpdated = false;

            isUpdated |= UpdateUserName(user, command.Name);
            isUpdated |= UpdateUserPassword(user, command.Password);
            isUpdated |= UpdateUserRole(user, command.Role);
            isUpdated |= await UpdateShop(user, command.ShopName);

            if (!isUpdated)
            {
                return user;
            }
            
            await _userRepository.UpdateAsync(user);
            return user;
        }
        
        private bool UpdateUserName(User user, string? newName)
        {
            if (!string.IsNullOrWhiteSpace(newName) && newName != user.Name)
            {
                user.Name = newName;
                return true;
            }
            return false;
        }
        private bool UpdateUserPassword(User user,string? newPassword)
        {
            if (!string.IsNullOrWhiteSpace(newPassword) && newPassword != user.Password)
            {
                user.Password = newPassword;
                return true;
            }
            return false;
        }
        private bool UpdateUserRole(User user, UserRole? newRole)
        {
            if (newRole != user.Role && newRole.HasValue)
            {
                user.Role = newRole.Value;
                return true;
            }
            return false;
        }

        private async Task<bool> UpdateShop(User user,string? shopName)
        {
            if (shopName != null) 
            {
                var shop = await _shopRepository.GetShopByName(shopName);
                if (shop != null && shop.Id != user.ShopId)
                {
                    DetachCurrentShop(user);
                    user.ShopId = shop.Id;
                    user.Shop = shop;
                    return true;
                }
            }
            else if(user.ShopId != null)
            {
                DetachCurrentShop(user);
                return true;
            }
            return false;
        }

        private void DetachCurrentShop(User user)
        {
            user.ShopId = null;
            user.Shop = null;
        }
    }
}
