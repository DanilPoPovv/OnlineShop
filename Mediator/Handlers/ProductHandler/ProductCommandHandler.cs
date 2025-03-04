using MediatR;
using OnlineShop.Mediator.Commands.ProductCommands;
using OnlineShop.Models;
using OnlineShop.Repositories.Interfaces;


namespace OnlineShop.Mediator.Handlers.ProductHandler
{
    public class ProductCommandHandler : IRequestHandler<AddProductCommand,Product>
    {
        IRepository<Product> _productRepository;

        ProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var Product = new Product
            {
                Name = command.Name,
                Quantity = command.Quantity,
                Price = command.Price,
                ShopId = command.ShopId,
            };
            await _productRepository.AddAsync(Product);

            return Product;
        }
    }
}
