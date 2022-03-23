using JoyPromotion.Business.Abstract;
using JoyPromotion.Shared.Utils.Security;
using JoyPromotion.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace JoyPromotion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var userListViewModel = new UserListViewModel
            {
                UserListDtos = _userService.GetAll()
            };
            return View(userListViewModel);
        }

        [Route("password-key")]
        public string Password()
        {
            return GenerateRandomPassword.Password();
        }

        [Route("get-captcha-image")]
        public string GetCaptchaImage()
        {
            return new string(GenerateRandomPassword.Password());
        }

        public IActionResult Add()
        {
            return View(new UserAddViewModel
            {
                Roles = new SelectList(_roleService.GetAll(), "Id", "Name")
            });

            //  UserAddDto = !string.IsNullOrEmpty(pass) ? new() { Password = GenerateRandomPassword.Password() } : null
        }

        [HttpPost]
        public IActionResult Add(UserAddViewModel userAddViewModel)
        {
            if (ModelState.IsValid)
            {
                _userService.Add(userAddViewModel.UserAddDto);
            }

            return View(userAddViewModel);
        }

        public IActionResult UserRoles(int roleId)
        {
            var userListViewModel = new UserListViewModel
            {
                UserListDtos = _userService.GetAllUsersBelongingToTheRole(roleId)
            };
            return View(userListViewModel);
        }
    }
}
