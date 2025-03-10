using MediatR;

namespace OnlineShop.Mediator.Commands.UserCommands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public string UserName { get; set; }
    }
}
