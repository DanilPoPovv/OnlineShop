using MediatR;
using OnlineShop.Mediator.Commands.ShopCommands;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.ShopHandler
{
    public class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommand,Shop>
    {
        IShopRepository _shopRepository;
        IUserRepository _userRepository;

        public UpdateShopCommandHandler(IShopRepository shopRepository,IUserRepository userRepository)
        {
            _shopRepository = shopRepository;
            _userRepository = userRepository;
        }
        public async Task<Shop> Handle(UpdateShopCommand command,CancellationToken cancellationToken) 
        {
            var shop = await _shopRepository.GetShopByIdIncludeManager(command.ShopId);
            bool isUpdated = false;
            if (shop == null)
            {
                return null!;
            }
            if (!string.IsNullOrWhiteSpace(command.ShopName) && shop.Name != command.ShopName)
            {
                shop.Name = command.ShopName;
                isUpdated = true;
            }
            ///TODO если у магазина был менеджер и мы добалвем нового - отвязать старого менеджера
            if (!string.IsNullOrEmpty(command.ManagerName) && shop.Manager?.Name != command.ManagerName) 
            {
                var user = await _userRepository.GetUserByUserName(command.ManagerName);
                if (user != null) 
                {
                    if (user.ManagedShopId == null && user.ShopId == null) 
                    {
                        shop.ManagerId = user.Id;
                        user.ManagedShopId = shop.Id;
                        user.ShopId = shop.Id;
                        isUpdated = true;
                    }
                    else 
                    {
                        throw new Exception("This user is already managing or selling another shop");
                    }
                }             
            }
            else if (command.ManagerName == null && shop.Manager != null)
            {
                shop.ManagerId = null;
                shop.Manager.ShopId = null;
                shop.Manager.ManagedShopId = null;
                isUpdated = true;
            }
            if (!isUpdated)
            {
                return shop;
            }
            await _shopRepository.UpdateAsync(shop);
            return shop;
        }
    }
}
