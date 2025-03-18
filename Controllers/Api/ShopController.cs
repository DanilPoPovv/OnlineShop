using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using OnlineShop.Mediator.Commands.ShopCommands;
using OnlineShop.Mediator.Queries.ShopQueries;

namespace OnlineShop.Controllers.Api
{
    [ApiController]
    [Route("api/shop")]
    public class ShopController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{shopId}")]
        public async Task<IActionResult>GetShop(int shopId)
        {
            var shop = await _mediator.Send(new GetShopByIdQuery {ShopId = shopId});
            return Ok(shop);
        }
        [HttpPost]
        public async Task<IActionResult> AddShop(AddShopCommand addShopCommand)
        {
            var shop = await _mediator.Send(addShopCommand);
            return Ok(shop);
        }
        [HttpPut]
        public async Task<IActionResult>ChangeShop(UpdateShopCommand updateShopCommand)
        {
            var shop = await _mediator.Send(updateShopCommand);
            return Ok(shop);
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteShop(DeleteShopCommand deleteShopCommand)
        {
            var shop = await _mediator.Send(deleteShopCommand);
            return Ok(shop);
        }
    }
}
