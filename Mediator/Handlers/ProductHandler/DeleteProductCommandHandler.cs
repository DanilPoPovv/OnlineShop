using OnlineShop.Repositories.Interfaces;
using OnlineShop.Models;
using MediatR;
using OnlineShop.Mediator.Commands.ProductCommands;
namespace OnlineShop.Mediator.Handlers.ProductHandler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,bool>
    {
        IRepository<Product> _productRepository;

        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            _productRepository = repository;
        }

        public async Task<bool> Handle(DeleteProductCommand command,CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.ProductId);
            if (product == null) 
            {
                return false;
            }
            await _productRepository.DeleteAsync(command.ProductId);
            return true;            
        }
    }

}
