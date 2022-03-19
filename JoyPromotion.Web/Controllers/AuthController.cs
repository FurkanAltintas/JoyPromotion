using JoyPromotion.Business.Abstract;
using JoyPromotion.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JoyPromotion.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View(new UserLoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_userService.CheckUser(userLoginViewModel.UserName, userLoginViewModel.Password))
                {
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, userLoginViewModel.UserName),
                        new(ClaimTypes.Role, "Admin")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = userLoginViewModel.RememberMe
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new(claimsIdentity), authProperties);


                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                ModelState.AddModelError("", "Kullanıcı adı veya parola hatalı");
            }

            return View(userLoginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait(); ile de yapabiliriz
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
