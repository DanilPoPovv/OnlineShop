using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Mediator.Commands.ShopCommands.ShopProductCommands;
using System.Security.Claims;

public class ProductController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IMediator mediator, ILogger<ProductController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
    {
        try
        {
            var product = await _mediator.Send(command);
            _logger.LogInformation("Product with {Name} was added by user {userName}", product.Name, User.Identity.Name);
            return Ok(new { message = "Product added successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding product");
            return BadRequest("Error adding product");
        }
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteProductCommand command) 
    {
        try
        {
            if (command == null)
            {
                return BadRequest("Invalid product data.");
            }
            var success = await _mediator.Send(command);
            if (!success)
            {
                return BadRequest("Product delete failed");
            }
            _logger.LogInformation("Product with {id} was deleted by user {userName}", command.ProductId, User.Identity.Name);
            return Ok(new { message = "Product successfully deleted" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting product with id {id}", command.ProductId);
            return BadRequest("Error deleting product");
        }
    }
    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] UpdateProductCommand command)
    {
        try
        {
            var product = await _mediator.Send(command);
            _logger.LogInformation("Product with {id} was changed by user {userName}", product.Id, User.Identity.Name);
            return Ok(new { message = "Product changed successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error changing product with id {id}", command.Id);
            return BadRequest("Error changing product");
        }
    }
}
