using MediatR;
using OnlineShop.Mediator.Commands.ShopCommands;
using OnlineShop.Repositories.Interfaces;
using OnlineShop.Exceptions.ShopExceptions;

namespace OnlineShop.Mediator.Handlers.ShopHandler
{
    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommand,bool>
    {
        IShopRepository _shopRepository;

        public DeleteShopCommandHandler(IShopRepository repository)
        {
            _shopRepository = repository;
        }
        public async Task<bool> Handle(DeleteShopCommand command, CancellationToken cancellationToken)
        {
            var shop = await _shopRepository.GetByIdAsync(command.ShopId);
            if (shop == null)
            {
                return false;
            }
            await _shopRepository.DeleteAsync(shop.Id);
            return true;
        }

    }
}
