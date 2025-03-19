using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineShop.Models.ViewModel;
using OnlineShop.Mediator.Queries.ShopQueries;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Mediator.Commands.ShopCommands;
using OnlineShop.Exceptions.ShopExceptions;
using OnlineShop.Mediator.Commands.ShopCommands.ShopProductCommands;
using Microsoft.AspNetCore.Components.Web;
using System.Xml.Serialization;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ShopController> _logger;
        public ShopController(IMediator mediator, ILogger<ShopController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        public async Task<IActionResult> Index(int id)
        {
            var shop = await _mediator.Send(new GetShopByIdQuery { ShopId = id });
            if (shop == null) { return NotFound(); }
            var employees = await _mediator.Send(new GetAllShopEmployeeQuery { shopId = shop.Id });
            var products = await _mediator.Send(new GetAllShopProductsQuery { shopId = shop.Id });
            var shopViewModel = new ShopViewModel
            {
                Shop = shop,
                Users = employees,
                Products = products,
            };
            return View(shopViewModel);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteShopCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Shop with {id} was deleted by user {userName}", command.ShopId, User.Identity.Name);
                return Ok(new { message = "Shop deleted succesfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting shop with id {id}", command.ShopId);
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddShopCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Shop with {Name} was added by user {userName}", command.Name, User.Identity.Name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding shop");
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateShopCommand command)
        {
            try
            {
                await _mediator.Send(command);
                _logger.LogInformation("Shop with {id} was updated by user {userName}", command.ShopId, User.Identity.Name);
                return Ok(new { message = "Shop updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating shop with id {id}", command.ShopId);
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddSeller([FromBody] AddSellerCommand command)
        {
            try
            {
                var user = await _mediator.Send(command);
                _logger.LogInformation("User with {id} was added as seller by user {userName}", user.Id, User.Identity.Name);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding seller");
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
