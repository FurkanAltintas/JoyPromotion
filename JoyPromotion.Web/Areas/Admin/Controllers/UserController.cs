using JoyPromotion.Business.Abstract;
using JoyPromotion.Dtos.Enums;
using JoyPromotion.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoyPromotion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var userListViewModel = new UserListViewModel
            {
                UserListDtos = _userService.GetAll()
            };
            return View(userListViewModel);
        }

        public IActionResult UserRoles(int roleId)
        {
            var role = RoleType.Admin;
            var role2 = RoleType.Admin.ToString();
            var role3 = RoleType.Admin.ToString("d");
            var role4 = RoleType.Admin.ToString("f");

            var userListViewModel = new UserListViewModel
            {
                UserListDtos = _userService.GetAllUsersBelongingToTheRole(roleId)
            };
            return View(userListViewModel);
        }
    }
}
