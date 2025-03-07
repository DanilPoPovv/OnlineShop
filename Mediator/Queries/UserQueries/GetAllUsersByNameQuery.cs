using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Queries.UserQueries
{
    public class GetAllUsersByNameQuery : IRequest<List<User>>
    {
        public string Username { get; set; }
    }
}
