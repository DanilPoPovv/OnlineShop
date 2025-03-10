using MediatR;
using OnlineShop.Mediator.Commands.ShopCommands.ShopProductCommands;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.ShopHandler.ShopProductHandler
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product?>
    {
        IRepository<Product> _productRepository;
        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _productRepository = repository;
        }
        public async Task<Product> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.Id);

            if (product == null)
            {
                return null!;
            }
            product.Name = command.Name ?? product.Name;
            product.Quantity = command.Quantity ?? product.Quantity;
            product.Price = command.Price ?? product.Price;
            await _productRepository.UpdateAsync(product);
            return product;
        }

    }
}
