using MediatR;
using OnlineShop.Mediator.Commands.ShopCommands;
using OnlineShop.Mediator.Queries.UserQueries;
using OnlineShop.Models.POCO;
using OnlineShop.Repositories.Interfaces;

namespace OnlineShop.Mediator.Handlers.ShopHandler
{
    public class AddShopCommandHandler : IRequestHandler<AddShopCommand, Shop>
    {
        IRepository<Shop> _shopRepository;
        IMediator _mediator;

        public AddShopCommandHandler(IRepository<Shop> shopRepository,IMediator mediator)
        {
            _shopRepository = shopRepository;
            _mediator = mediator;
        }

        public async Task<Shop> Handle(AddShopCommand command, CancellationToken cancellationToken)
        {
            var manager = string.IsNullOrEmpty(command.ManagerName) ? await _mediator.Send(new GetUserByUserNameQuery() { UserName = command.ManagerName }) : null;
            var shop = new Shop
            {
                Name = command.Name,
                ManagerId = manager?.Id,
            };
            await _shopRepository.AddAsync(shop);
            return shop;
        }

    }
}
