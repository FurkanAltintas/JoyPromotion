using JoyPromotion.Business.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoyPromotion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var roleListViewModel = new RoleListViewModel
            {
                RoleListDtos = _roleService.GetAll()
            };

            return View(roleListViewModel);
        }

        public IActionResult Edit(int roleId)
        {
            var roleUpdateViewModel = new RoleUpdateViewModel
            {
                RoleUpdateDto = _roleService.Convert<RoleUpdateDto>(_roleService.GetById(roleId))
            };

            return View(roleUpdateViewModel);
        }

        [HttpPost]
        public IActionResult Edit(RoleUpdateViewModel roleUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                _roleService.Update(roleUpdateViewModel.RoleUpdateDto);
                return RedirectToAction(nameof(Index));
            }

            return View(roleUpdateViewModel);
        }
    }
}
