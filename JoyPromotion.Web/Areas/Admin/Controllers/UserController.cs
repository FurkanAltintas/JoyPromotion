using JoyPromotion.Business.Abstract;
using JoyPromotion.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace JoyPromotion.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = new UserListViewModel
            {
                UserListDtos = _userService.GetAll()
            };
            return View(model);
        }
    }
}
