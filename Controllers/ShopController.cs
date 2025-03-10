﻿/*using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineShop.Models.ViewModel;
using OnlineShop.Mediator.Queries.ShopQueries;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;
        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> AddShop(string Name)
        {
            var shop = await _mediator.Send(new GetShopByIdQuery {Id = id }, cancellationToken:default);
            var model = new ShopViewModel
            {
                Shop = shop,
                Products = shop.Products,
                Users = shop.Employees

            };
            return View(model);
        }
    }
}
*/