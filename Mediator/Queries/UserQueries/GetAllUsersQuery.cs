using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
