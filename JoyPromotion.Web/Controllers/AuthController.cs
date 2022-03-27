using JoyPromotion.Business.Abstract;
using JoyPromotion.Shared.Utils.EmailSender;
using JoyPromotion.Web.Extensions;
using JoyPromotion.Web.Models;
using JoyPromotion.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JoyPromotion.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AuthController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult Login()
        {
            return View(new UserLoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            var user = _userService.LoginUser(userLoginViewModel.UserName, userLoginViewModel.Password);
            if (ModelState.IsValid)
            {
                if (user != null) // _userService.CheckUser(userLoginViewModel.UserName, userLoginViewModel.Password)
                {
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, userLoginViewModel.UserName),
                        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new(ClaimTypes.Role, _roleService.GetById(user.RoleId).Name)
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

        public IActionResult PasswordReset()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PasswordReset(string email)
        {
            #region Eski Yöntem Mail Atma
            // var callBackUrl = Url.Action("ResetPassword", "Auth", new { userId = 1, code = Guid.NewGuid().ToString() });
            //EmailSender(email, this.CallBackUrl());
            #endregion

            this.SenderRequest(email, EmailSenderRequest.PasswordReset);

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait(); ile de yapabiliriz
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        #region Eski Yöntem Mail Atma
        //public void EmailSender(string email, string callBackUrl)
        //{
        //    #region Email Sender
        //    Mail mail = new();
        //    var request = HttpContext.Request;
        //    var baseUrl = $"{request.Scheme}://{request.Host}" + callBackUrl;
        //    string body = new Template().PasswordReset(baseUrl);
        //    mail.MailSend(email, body, Mail.PasswordReset);
        //    #endregion
        //}
        #endregion
    }
}
