using MediatR;
using OnlineShop.Models.POCO;
using System.Security.Principal;

namespace OnlineShop.Mediator.Queries.UserQueries
{
    public class GetUserByUserNameQuery : IRequest<User>
    {
        public string UserName { get; set; }
    }
}
