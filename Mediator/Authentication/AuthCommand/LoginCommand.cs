using MediatR;
using OnlineShop.Models.Dto;

namespace OnlineShop.Mediator.Authentication.AuthCommand
{
    public class LoginCommand : IRequest<UserDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
