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
        public async Task<IActionResult> Index(string? searchUsers, string? searchShops,int usersPageNumber = 1,int shopsPageNumber = 1,int pageSize = 7)
        {
            var userQuery = new GetUsersWithPaginationQuery(usersPageNumber, pageSize, searchUsers);
            var shopQuery = new GetShopsWithPaginationQuery(shopsPageNumber, pageSize, searchShops); 

            var users = await _mediator.Send(userQuery);
            var shops = await _mediator.Send(shopQuery);

            var searchResults = new SearchViewModel
            {
                Users = users,
                Shops = shops,
                UserSearchTerm = searchUsers,
                ShopSearchTerm = searchShops,
                UsersPageNumber = usersPageNumber,
                UsersTotalPages = users.TotalPages,
                ShopsPageNumber = shopsPageNumber,
                ShopsTotalPages = shops.TotalPages
            };

            return View(searchResults);
        }
    }
}
