﻿using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineShop.Models.ViewModel;
using OnlineShop.Mediator.Queries.ShopQueries;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Mediator.Commands.ShopCommands;
using OnlineShop.Exceptions.ShopExceptions;

namespace OnlineShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;
        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<IActionResult> Delete([FromBody]DeleteShopCommand command) 
        {
            var result = await _mediator.Send(command);
            if (!result)
            {
                throw new ShopNotFoundException($"Failed to delete shop");
            }
            return Ok(new { message = "Shop deleted succesfully" });
        }
    }
}
