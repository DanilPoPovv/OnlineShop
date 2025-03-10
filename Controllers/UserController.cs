using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.POCO;
using OnlineShop.Mediator.Queries;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Mediator.Commands;
using OnlineShop.Mediator.Commands.UserCommands;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name,string password,UserRole role,string? shopName)
        {
            var shop = shopName != null ? await _mediator.Send(new GetShopByNameQuery() {ShopName = name }) : null;
            var user = await _mediator.Send(new AddUserCommand() { Name = name, Password = password, Role = role, shop = shop });
            return Ok(user);
        }
    }
}
