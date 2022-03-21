using JoyPromotion.Business.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

        int pageSize = 4;
        public IActionResult Index(int? page)
        {
            Thread.Sleep(1000);

            IEnumerable<ContentListDto> contents = null;
            var takeTheLast = _contentService.TakeTheLast();

            if (!page.HasValue) // HasValue içerisinde değer olup olmadığını kontrol ediyor
            {
                // içerisi boş ise
                contents = _contentService.GetAllOrderBy().Take(pageSize);
            }
            else
            {
                // page numarası dolu ise
                int pageIndex = pageSize * page.Value;
                contents = _contentService.GetAllOrderBy().Skip(pageIndex).Take(pageSize);
            }

            if (page != null)
            {
                return PartialView("_Content", new ContentListViewModelUI
                {
                    ContentListDtos = contents,
                    ContentDto = takeTheLast
                });
            }

            var model = new ContentListViewModelUI
            {
                ContentListDtos = contents,
                ContentDto = takeTheLast
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
