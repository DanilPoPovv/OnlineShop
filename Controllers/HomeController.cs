using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineShop.Models.ViewModel;
using OnlineShop.Mediator.Commands;
using OnlineShop.Mediator.Queries.ShopQueries;
using OnlineShop.Mediator.Queries.UserQueries;
using OnlineShop.Mediator.Search.SearchQueries;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(string? searchUsers, string? searchShops)
        {
            var searchQuery = new SearchShopsAndUsersQuery
            {
                Username = searchUsers,
                ShopName = searchShops
            };
            SearchViewModel searchResults = await _mediator.Send(searchQuery);

            return View(searchResults);

        }
    }
}
