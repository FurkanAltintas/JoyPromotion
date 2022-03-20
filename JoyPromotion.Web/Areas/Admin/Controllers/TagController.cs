using JoyPromotion.Business.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoyPromotion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            var model = new TagListViewModel
            {
                TagListDtos = _tagService.GetAll()
            };

            return View(model);
        }

        public IActionResult Add()
        {
            return View(new TagAddViewModel());
        }

        [HttpPost]
        public IActionResult Add(TagAddDto tagAddDto)
        {
            if (ModelState.IsValid)
            {
                _tagService.Add(tagAddDto);
                return RedirectToAction(nameof(Index));
            }

            return View(new TagAddViewModel { TagAddDto = tagAddDto });
        }

        public IActionResult Edit(int Id)
        {
            var tagUpdateDto = _tagService.Convert<TagUpdateDto>(_tagService.GetById(Id));
            return View(new TagUpdateViewModel { TagUpdateDto = tagUpdateDto });
        }

        [HttpPost]
        public IActionResult Edit(TagUpdateDto tagUpdateDto)
        {
            if (ModelState.IsValid)
            {
                _tagService.Update(tagUpdateDto);
                return RedirectToAction(nameof(Index));
            }

            return View(new TagUpdateViewModel { TagUpdateDto = tagUpdateDto });
        }
    }
}
