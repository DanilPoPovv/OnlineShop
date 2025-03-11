using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Authentication.AuthQuery
{
    public class GetUserByUserNameQuery : IRequest<User>
    {
        public string Username { get; set; }
        public UserRole Role { get; set; }
    }
}
