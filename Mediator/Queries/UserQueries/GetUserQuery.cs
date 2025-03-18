using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Queries.UserQueries
{
    public class GetUserQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
