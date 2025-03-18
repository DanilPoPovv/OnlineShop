using MediatR;
using OnlineShop.Models.POCO;

namespace OnlineShop.Mediator.Queries.ProductQueries
{
    public class GetProductQuery : IRequest<Product>
    {
        public int ProductId { get; set; }
    }
}
