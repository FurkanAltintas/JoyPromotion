using JoyPromotion.Business.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Web.Areas.Admin.Models;
using JoyPromotion.Web.Extensions;
using JoyPromotion.Web.Utils;
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
        private readonly ITagService _tagService;
        private readonly IContentTagService _contentTagService;

        public ContentController(IContentService contentService, ICategoryService categoryService, ITagService tagService, IContentTagService contentTagService)
        {
            _contentService = contentService;
            _categoryService = categoryService;
            _tagService = tagService;
            _contentTagService = contentTagService;
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
            return View(new ContentAddViewModel
            {
                CategoryListDtos = _categoryService.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                TagListDtos = _tagService.GetAll().Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                })
            });
        }

        [HttpPost]
        public IActionResult Add(ContentAddViewModel contentAddViewModel)
        {
            if (ModelState.IsValid)
            {
                new ImageFile().Upload(contentAddViewModel.Image, out string imageUrl);
                contentAddViewModel.ContentAddDto.ImageUrl = imageUrl;
                _contentService.Insert(contentAddViewModel.ContentAddDto, this.UserKey(), out int contentId);
                _contentTagService.Add(contentAddViewModel.TagId, contentId);
                return RedirectToAction(nameof(Index));
            }

            return View(contentAddViewModel);
        }

        public IActionResult Edit(int id)
        {
            var contentUpdateDto = _contentService.Convert<ContentUpdateDto>(_contentService.GetById(id));
            return View(new ContentUpdateViewModel
            {
                ContentUpdateDto = contentUpdateDto,
                CategoryListDtos = _categoryService.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                TagListDtos = _tagService.GetAll().Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                }),
                ContentTagFetchDtos = _contentTagService.FetchTagsOfContent(id)
            });
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
