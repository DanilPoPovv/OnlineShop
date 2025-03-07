using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using OnlineShop.Mediator.Commands.ShopCommands;

namespace OnlineShop.Controllers.Api
{
    [ApiController]
    [Route("api/shop")]
    public class TestController : Controller
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddShop(AddShopCommand addShopCommand)
        {
            var shop = await _mediator.Send(addShopCommand);
            return Ok(shop);
        }
    }
}
