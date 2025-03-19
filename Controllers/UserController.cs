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
        private readonly ILogger<UserController> _logger;
        IMediator _mediator;
        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddUserCommand command)
        {
            try
            {
                var user = await _mediator.Send(command);
                _logger.LogInformation("User with {Username} was added by user {userName}", command.Name, User.Identity.Name);
                return Ok(new { message = "User created successfully" });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error adding user");
                return BadRequest("Error adding user");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command) 
        {
            try
            {
                await _mediator.Send(command);
                _logger.LogInformation("User with name {id} was deleted by user {userName}", command.UserName, User.Identity.Name);
                return Ok(new { message = "User deleted successfully" });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error deleting user with name {id}", command.UserName);
                return BadRequest("Error deleting user");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateUsersCommand command) 
        {
            try
            {
                var updatedUser = await _mediator.Send(command);
                _logger.LogInformation("User with name {name} was updated by user {userName}", command.Name, User.Identity.Name);
                return Ok(new { message = "User updated seccessfully" });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error updating user with name {id}", command.Name);
                return BadRequest("Error updating user");
            }
        }
    }
}
