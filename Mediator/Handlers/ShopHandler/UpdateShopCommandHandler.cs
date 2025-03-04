using MediatR;
using OnlineShop.Mediator.Commands.ShopCommands;
using OnlineShop.Models;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.ShopHandler
{
    public class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommand,Shop>
    {
        IRepository<Shop> _shopRepository;
        public UpdateShopCommandHandler(IRepository<Shop> repository)
        {
            _shopRepository = repository;
        }
        public async Task<Shop> Handle(UpdateShopCommand command,CancellationToken cancellationToken) 
        {
            var shop = await _shopRepository.GetByIdAsync(command.ShopId);
            if (shop == null)
            {
                return null!;
            }
            shop.Name = command.Name ?? shop.Name;
            shop.ManagerId = command.ManagerId ?? shop.ManagerId;
            await _shopRepository.UpdateAsync(shop);
            return shop;
        }
    }
}
