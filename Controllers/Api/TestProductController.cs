using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineShop.Mediator.Commands.ShopCommands.ShopProductCommands;

namespace OnlineShop.Controllers.Api
{
    [ApiController]
    [Route("api/product")]
    public class TestProductController : Controller
    {
        private readonly IMediator _mediator;
        public TestProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddProductToShop(AddProductCommand command)
        {
            var product = await _mediator.Send(command);
            return Ok(product);
        }
    }
}
