using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Mediator.Authentication.AuthCommand;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using OnlineShop.Models.Dto;
using OnlineShop.Models.ViewModel;
using System.Security.Claims;

namespace OnlineShop.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _mediator.Send(new LoginCommand { Password = model.Password, Username = model.Username});
            

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
            };
            Console.WriteLine(user.Role.ToString());

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
