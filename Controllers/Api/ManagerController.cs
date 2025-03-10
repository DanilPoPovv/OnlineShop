using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Mediator.Commands.UserCommands;

namespace OnlineShop.Controllers.Api
{
    [ApiController]
    [Route("api/manager")]
    public class ManagerController : Controller
    {
        IMediator _mediator;
        public ManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddManager(AddManagerCommand command)
        {
            var manager = await _mediator.Send(command);
            return Ok(manager);   
        }
    }
}
