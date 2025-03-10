using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Mediator.Commands.UserCommands;

namespace OnlineShop.Controllers.Api
{
    [ApiController]
    [Route("api/employee")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployeeToShop(AddUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }
    }
}
