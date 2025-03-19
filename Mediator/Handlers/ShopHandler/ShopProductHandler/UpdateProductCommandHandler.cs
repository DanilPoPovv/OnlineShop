using MediatR;
using OnlineShop.Exceptions.ProductExceptions;
using OnlineShop.Mediator.Commands.ShopCommands.ShopProductCommands;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;
using System.Linq.Expressions;

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
            bool isUpdated = false;
            if (product == null)
            {
                throw new ProductNotFoundException("Product was not found");
            }
            if (!string.IsNullOrWhiteSpace(command.Name) && command.Name != product.Name) 
            {
                product.Name = command.Name;
                isUpdated = true;
            }
            if (command.Price.HasValue && command.Price != product.Price)
            {
                product.Price = command.Price.Value;
                isUpdated = true;
            }
            if (command.Quantity.HasValue  && command.Quantity != product.Quantity)
            {
                product.Quantity = command.Quantity.Value;
                isUpdated = true;
            }
            if (isUpdated)
            {
                await _productRepository.UpdateAsync(product);
            }
            return product;

        }

    }
}
