using MediatR;
using OnlineShop.Mediator.Commands.ShopCommands;
using OnlineShop.Repositories.Interfaces;
using OnlineShop.Models.POCO;
using OnlineShop.Exceptions.UserExceptions;

namespace OnlineShop.Mediator.Handlers.ShopHandler
{
    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopByShopNameCommand,bool>
    {
        IShopRepository _shopRepository;

        public DeleteShopCommandHandler(IShopRepository repository)
        {
            _shopRepository = repository;
        }
        public async Task<bool> Handle(DeleteShopByShopNameCommand command, CancellationToken cancellationToken)
        {
            var shop = await _shopRepository.GetShopByName(command.ShopName);
            if (shop == null)
            {
                throw new UserNotFoundException($"User with name {command.ShopName} not found");
            }
            await _shopRepository.DeleteAsync(shop.Id);
            return true;
        }

    }
}
