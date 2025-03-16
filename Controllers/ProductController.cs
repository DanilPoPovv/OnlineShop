using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Mediator.Commands.ShopCommands.ShopProductCommands;

public class ProductController : Controller
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody]AddProductCommand command)
    {
        if (command == null)
            return BadRequest("Invalid product data.");

        var product = await _mediator.Send(command);
        if (product == null)
            return BadRequest("Failed to add product.");

        return Ok(product);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteProductCommand command) 
    {
        var success = await _mediator.Send(command);
        if (!success)
        {
            return BadRequest("Product delete failed");
        }
        return Ok(new { message = "Product successfully deleted"});
    }
    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] UpdateProductCommand command)
    {
        Console.WriteLine(command.Id);
        var product = await _mediator.Send(command);
        return Ok(new { message = "Product changed successfully" });
    }
}
