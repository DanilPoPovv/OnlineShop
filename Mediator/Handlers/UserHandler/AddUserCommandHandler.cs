using MediatR;
using OnlineShop.Repositories.Interfaces;
using OnlineShop.Mediator.Commands.UserCommands;
using OnlineShop.Models.POCO;
using OnlineShop.Mediator.Queries.ShopQueries;

namespace OnlineShop.Mediator.Handlers.UserHandler
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMediator _mediator;
        public AddUserCommandHandler(IRepository<User> userRepository,IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }
        public async Task<User> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            var shop = !string.IsNullOrEmpty(command.ShopName) ? await _mediator.Send(new GetShopByNameQuery() { ShopName = command.ShopName }) : null;
            var user = new User
            {
                Name = command.Name,
                Password = command.Password,
                Role = command.Role,
                ShopId = shop?.Id,
            };
            await _userRepository.AddAsync(user);
            return user;
        }
    }
}
