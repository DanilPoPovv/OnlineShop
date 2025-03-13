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
        IRepository<Product> _productRepository;

        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            _productRepository = repository;
        }

        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(command.ProductId);
            return true;
        }
    }

}
