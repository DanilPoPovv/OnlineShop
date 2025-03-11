using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.POCO;
using OnlineShop.Mediator.Queries;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Mediator.Commands;
using OnlineShop.Mediator.Commands.UserCommands;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Exceptions.UserExceptions;

namespace OnlineShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }
        [HttpDelete]
        ///TODO нужно так же обрабатывать случаи когда пользователь удаляет сам себя и разлогинивать его.
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command) 
        {
            var success = await _mediator.Send(command);
            if (!success)
            {
                throw new UserDeleteException($"user delete failed");
            }
            return Ok(new {message = "User deleted successfully"});
        }
    }
}
