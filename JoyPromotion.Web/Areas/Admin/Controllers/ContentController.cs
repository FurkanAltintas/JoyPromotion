using JoyPromotion.Business.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace JoyPromotion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly ICategoryService _categoryService;

        public ContentController(IContentService contentService, ICategoryService categoryService)
        {
            _contentService = contentService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var model = new ContentListViewModel
            {
                ContentListDtos = _contentService.GetAll()
            };

            return View(model);
        }

        public IActionResult Add()
        {
            return View(new ContentAddViewModel { CategoryListDtos = _categoryService.GetAll().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }) });
        }

        [HttpPost]
        public IActionResult Add(ContentAddDto contentAddDto)
        {
            if (ModelState.IsValid)
            {
                _contentService.Add(contentAddDto);
                return RedirectToAction(nameof(Index));
            }

            return View(new ContentAddViewModel { ContentAddDto = contentAddDto });
        }

        public IActionResult Edit(int Id)
        {
            var contentUpdateDto = _contentService.Convert<ContentUpdateDto>(_contentService.GetById(Id));
            return View(new ContentUpdateViewModel { ContentUpdateDto = contentUpdateDto });
        }

        [HttpPost]
        public IActionResult Edit(ContentUpdateDto contentUpdateDto)
        {
            if (ModelState.IsValid)
            {
                _contentService.Update(contentUpdateDto);
                return RedirectToAction(nameof(Index));
            }

            return View(new ContentUpdateViewModel { ContentUpdateDto = contentUpdateDto });
        }
    }
}
