using JoyPromotion.Business.Abstract;
using JoyPromotion.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace JoyPromotion.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IUserSocialMediaService _userSocialMediaService;

        public HomeController(IContentService contentService, IUserSocialMediaService userSocialMediaService)
        {
            _contentService = contentService;
            _userSocialMediaService = userSocialMediaService;
        }

        public IActionResult Index()
        {
            var model = new ContentListViewModelUI
            {
                ContentListDtos = _contentService.GetAllOrderBy(),
                ContentDto = _contentService.TakeTheLast()
            };

            return View(model);
        }

        public IActionResult Details(int Id)
        {
            var content = _contentService.GetById(Id);
            var model = new ContentViewModelUI
            {
                ContentDto = content,
                TakeTheLastThreeDtos = _contentService.TakeTheLastThree(Id),
                GetUserSocialMediaDtos = _userSocialMediaService.GetUserSocialMedia(content.UserId)
            };

            return View(model);
        }
    }
}
