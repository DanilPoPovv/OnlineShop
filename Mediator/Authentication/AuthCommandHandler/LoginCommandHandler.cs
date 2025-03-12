using MediatR;
using OnlineShop.Mediator.Authentication.AuthCommand;
using OnlineShop.Mediator.Authentication.AuthQuery;
using OnlineShop.Models.Dto;

namespace OnlineShop.Mediator.Authentication.AuthCommandHandler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand,UserDto>
    {
        private readonly IMediator _mediator;
        public LoginCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<UserDto> Handle(LoginCommand command,CancellationToken cancellationToken) 
        {
            var user = await _mediator.Send(new GetUserByUserNameAuthQuery { Username = command.Username }, cancellationToken);

            if (user == null || user.Password != command.Password)
            {
                return null!;
            }
            return new UserDto
            {
                Id = user.Id,
                UserName = command.Username,
                Role = user.Role
            };
        }
    }
}
