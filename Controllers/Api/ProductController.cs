using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Mediator.Commands.ShopCommands.ShopProductCommands;
using OnlineShop.Mediator.Queries.ProductQueries;

namespace OnlineShop.Controllers.Api
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var product = await _mediator.Send(new GetProductQuery { ProductId = productId});
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult>AddProduct(AddProductCommand command)
        {
            var product = await _mediator.Send(command);
            return Ok(product);
        }
        [HttpPut]
        public async Task<IActionResult>UpdateProduct(UpdateProductCommand command)
        {
            var product = await _mediator.Send(command);
            return Ok(product);
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteProduct(DeleteProductCommand command)
        {
            var product = await _mediator.Send(command);
            return Ok(product);
        }
    }
}
