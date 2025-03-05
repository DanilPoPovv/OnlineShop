using MediatR;
using OnlineShop.Models;

namespace OnlineShop.Mediator.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
