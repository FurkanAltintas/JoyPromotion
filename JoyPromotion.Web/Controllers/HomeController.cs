using JoyPromotion.Business.Abstract;
using JoyPromotion.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace JoyPromotion.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContentService _contentService;

        public HomeController(IContentService contentService)
        {
            _contentService = contentService;
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
            var model = new ContentViewModelUI
            {
                ContentDto = _contentService.GetById(Id)
            };

            return View(model);
        }
    }
}
