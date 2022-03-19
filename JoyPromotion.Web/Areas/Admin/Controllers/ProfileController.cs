﻿using JoyPromotion.Business.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace JoyPromotion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = new UserViewModel
            {
                Users = _userService.FindByName(User.Identity.Name)
            };
            return View(model);
        }

        public IActionResult Update()
        {
            return View(new UserViewModel
            {
                Users = _userService.FindByName(User.Identity.Name)
            });
        }

        [HttpPost]
        public IActionResult Update(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    var imageName = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                    var path = Directory.GetCurrentDirectory() + "/wwwroot/img/" + imageName;
                    var stream = new FileStream(path, FileMode.Create);
                    model.Image.CopyTo(stream);
                    model.Users.ImageUrl = imageName;
                }

                _userService.Update(model.Users);
                return RedirectToAction("Update");
            }
            return View(model);
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
                var user = _userService.FindByName(User.Identity.Name);
                user.Password = userPasswordDto.Password;
                _userService.Update(user);
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "Auth");
            }

            return View(userPasswordDto);
        }
    }
}
