using OnlineShop.Repositories.Interfaces;
using MediatR;
using OnlineShop.Models.POCO;
using OnlineShop.Mediator.Commands.ShopCommands.ShopProductCommands;
using OnlineShop.Exceptions.ShopExceptions;
using OnlineShop.Exceptions.ProductExceptions;
namespace OnlineShop.Mediator.Handlers.ShopHandler.ShopProductHandler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        IShopRepository _shopRepository;

        public DeleteProductCommandHandler(IShopRepository repository)
        {
            _shopRepository = repository;
        }

        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var shop = await _shopRepository.GetShopByName(command.ShopName);
            if (shop == null)
            {
                throw new ShopNotFoundException($"Shop witn name {command.ShopName} not found");
            }
            var deleteSuccess = await _shopRepository.DeleteShopProduct(shop,command.ProductName);
            if (!deleteSuccess) 
            {
                throw new ProductNotFoundException($"Product with name {command.ProductName} not found");
            }
            return deleteSuccess;

        }
    }

}
