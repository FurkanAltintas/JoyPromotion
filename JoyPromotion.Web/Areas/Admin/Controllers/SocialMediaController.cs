using JoyPromotion.Business.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoyPromotion.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IActionResult Index()
        {
            var model = new SocialMediaListViewModel
            {
                SocialMediaListDto = _socialMediaService.GetAll()
            };

            return View(model);
        }

        public IActionResult Add()
        {
            return View(new SocialMediaAddViewModel());
        }

        [HttpPost]
        public IActionResult Add(SocialMediaAddDto socialMediaAddDto)
        {
            if (ModelState.IsValid)
            {
                _socialMediaService.Add(socialMediaAddDto);
                return RedirectToAction(nameof(Index));
            }

            return View(new SocialMediaAddViewModel { SocialMediaAddDto = socialMediaAddDto});
        }

        public IActionResult Edit(int Id)
        {
            var socialMediaUpdateDto = _socialMediaService.Convert<SocialMediaUpdateDto>(_socialMediaService.GetById(Id));

            return View(new SocialMediaUpdateViewModel { SocialMediaUpdateDto = socialMediaUpdateDto });
        }

        [HttpPost]
        public IActionResult Edit(SocialMediaUpdateDto socialMediaUpdateDto)
        {
            if (ModelState.IsValid)
            {
                _socialMediaService.Update(socialMediaUpdateDto);
                return RedirectToAction(nameof(Index));
            }

            return View(new SocialMediaUpdateViewModel { SocialMediaUpdateDto = socialMediaUpdateDto });
        }
    }
}
