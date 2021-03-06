using JoyPromotion.Business.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Web.Areas.Admin.Models;
using JoyPromotion.Web.Extensions;
using JoyPromotion.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoyPromotion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProfileController : BaseController
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }



        public IActionResult Update()
        {
            return View(new UserUpdateViewModel
            {
                UserUpdateDto = _userService.Convert<UserUpdateDto>(User)
            });
        }

        [HttpPost]
        public IActionResult Update(UserUpdateViewModel userUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (userUpdateViewModel.Image != null)
                {
                    new ImageFile().Upload(userUpdateViewModel.Image, out string imageUrl);
                    userUpdateViewModel.UserUpdateDto.ImageUrl = imageUrl;
                }
                _userService.Update(userUpdateViewModel.UserUpdateDto);
                return RedirectToAction(nameof(Update));
            }
            return View(userUpdateViewModel);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(UserPasswordDto userPasswordDto)
        {
            if (ModelState.IsValid)
            {
                _userService.PaswordUpdate(userPasswordDto.Password, this.UserKey());
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "Auth");
            }

            return View(userPasswordDto);
        }

        #region Eski Yöntem
        //public UserDto FindUser()
        //{
        //    return _userService.FindByName(this.UserName());
        //}
        #endregion
    }
}
