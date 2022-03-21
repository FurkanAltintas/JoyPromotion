using JoyPromotion.Business.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JoyPromotion.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public UserDto User { get; set; }

        private readonly IUserService _userService;

        public BaseController(IUserService userService)
        {
            _userService = userService;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            User = _userService.GetById(this.UserKey());
            base.OnActionExecuted(context);
        }
    }
}
