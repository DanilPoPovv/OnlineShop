using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineShop.Models.ViewModel;
using OnlineShop.Mediator.Search.SearchQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public readonly IMediator _mediator;
        private readonly ILogger<HomeController> _logger;
        public HomeController(IMediator mediator, ILogger<HomeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        public async Task<IActionResult> Index(string? searchUsers, string? searchShops)
        {
            var searchQuery = new SearchShopsAndUsersQuery
            {
                Username = searchUsers,
                ShopName = searchShops
            };
            SearchViewModel searchResults = await _mediator.Send(searchQuery);
            _logger.LogInformation("User searched for {searchUsers} and {searchShops}", searchUsers, searchShops);
            return View(searchResults);

        }
    }
}
