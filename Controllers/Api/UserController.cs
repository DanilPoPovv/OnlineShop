using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineShop.Mediator.Commands.UserCommands;
using OnlineShop.Mediator.Queries.UserQueries;

namespace OnlineShop.Controllers.Api
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult>GetUser(int userId)
        {
            var user = await _mediator.Send(new GetUserQuery { Id = userId});
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult>AddUser(AddUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }
        [HttpPut]
        public async Task<IActionResult>ChangeUser(UpdateUsersCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }
    }
}
