using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineShop.Mediator.Commands.ShopCommands;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.ShopHandler
{
    public class AddShopCommandHandler : IRequestHandler<AddShopCommand, Shop>
    {
        IRepository<Shop> _shopRepository;

        public AddShopCommandHandler(IRepository<Shop> shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<Shop> Handle(AddShopCommand command, CancellationToken cancellationToken)
        {
            var shop = new Shop
            {
                Name = command.Name,
                ManagerId = command.ManagerId,
            };
            await _shopRepository.AddAsync(shop);
            return shop;
        }

    }
}
