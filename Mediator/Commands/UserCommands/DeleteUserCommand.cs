using MediatR;

namespace OnlineShop.Mediator.Commands.UserCommands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }
}
