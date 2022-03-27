using JoyPromotion.Business.Abstract;
using JoyPromotion.Web.Areas.Admin.Models;
using JoyPromotion.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult Add(IFormCollection pass)
        {
            string password = pass["pass"];

            return View(new UserAddViewModel
            {
                Roles = new SelectList(_roleService.GetAll(), "Id", "Name")
            });
        }

        [HttpPost]
        public IActionResult Add(UserAddViewModel userAddViewModel)
        {
            if (ModelState.IsValid)
            {
                _userService.Add(userAddViewModel.UserAddDto);
                this.SenderRequest(userAddViewModel.UserAddDto.Email, EmailSenderRequest.EmailConfirmed);
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
