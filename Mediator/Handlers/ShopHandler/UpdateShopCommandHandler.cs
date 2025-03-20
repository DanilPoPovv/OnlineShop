using MediatR;
using OnlineShop.Exceptions.ShopExceptions;
using OnlineShop.Exceptions.UserExceptions;
using OnlineShop.Mediator.Commands.ShopCommands;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnlineShop.Mediator.Handlers.ShopHandler
{
    public class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommand, Shop>
    {
        IShopRepository _shopRepository;
        IUserRepository _userRepository;
        public UpdateShopCommandHandler(IShopRepository shopRepository, IUserRepository userRepository)
        {
            _shopRepository = shopRepository;
            _userRepository = userRepository;
        }
        public async Task<Shop> Handle(UpdateShopCommand command, CancellationToken cancellationToken)
        {
            var shop = await _shopRepository.GetShopByIdIncludeManager(command.ShopId);
            bool isUpdated = false;

            if (shop == null)
            {
                throw new ShopNotFoundException($"Shop with name {command.ShopName} was not found");
            }

            if (shop.Name != command.ShopName)
            {
                shop.Name = command.ShopName!;
                isUpdated = true;
            }

            isUpdated |= await UpdateShopManager(shop, command.ManagerName);

            if (!isUpdated)
            {
                return shop;
            }

            await _shopRepository.UpdateAsync(shop);
            return shop;
        }
        private async Task<bool> UpdateShopManager(Shop shop, string? newManagerName)
        {
            if (string.IsNullOrEmpty(newManagerName) && shop.Manager != null)
            {
                DetachCurrentManager(shop);
                return true;
            }
            if (newManagerName != null)
            {
                var newManager = await _userRepository.GetUserByUserName(newManagerName);
                if (newManager == null)
                {
                    throw new UserNotFoundException($"Manager with name {newManagerName} was not found");
                }
                if (newManager.ShopId == null || newManager.ShopId == shop.Id)
                {
                    DetachCurrentManager(shop);
                    newManager.ManagedShopId = shop.Id;
                    shop.ManagerId = newManager.Id;
                    return true;
                }
                else
                {
                    throw new Exception("This user is already assigned to another shop");
                }
            }
            return false;
        }
        private void DetachCurrentManager(Shop shop)
        {
            if (shop.Manager != null)
            {
                shop.Manager.ShopId = null;
                shop.Manager.ManagedShopId = null;
                shop.ManagerId = null;
            }
        }
    }
}