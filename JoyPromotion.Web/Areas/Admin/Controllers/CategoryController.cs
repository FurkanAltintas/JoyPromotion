using JoyPromotion.Business.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoyPromotion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Writer")]
    //[Filters.Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var area = ControllerContext.ActionDescriptor.RouteValues["area"];
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            var model = new CategoryListViewModel
            {
                CategoryListDtos = _categoryService.GetAll()
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View(new CategoryAddViewModel());
        }

        [HttpPost]
        public IActionResult Add(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(categoryAddDto);
                return RedirectToAction(nameof(Index));
            }
            return View(new CategoryAddViewModel { CategoryAddDto = categoryAddDto });
        }

        public IActionResult Edit(int Id)
        {
            var categoryUpdateDto = _categoryService.Convert<CategoryUpdateDto>(_categoryService.GetById(Id));

            return View(new CategoryUpdateViewModel { CategoryUpdateDto = categoryUpdateDto });
        }

        [HttpPost]
        public IActionResult Edit(CategoryUpdateDto categoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(categoryUpdateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(new CategoryUpdateViewModel { CategoryUpdateDto = categoryUpdateDto });
        }
    }
}
