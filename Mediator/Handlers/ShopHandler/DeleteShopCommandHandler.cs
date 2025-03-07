using MediatR;
using OnlineShop.Mediator.Commands.ShopCommands;
using OnlineShop.Repositories.Interfaces;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Handlers.ShopHandler
{
    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommand,bool>
    {
        IRepository<Shop> _shopRepository;

        public DeleteShopCommandHandler(IRepository<Shop> repository)
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
            await _shopRepository.DeleteAsync(command.ShopId);
            return true;
        }

    }
}
