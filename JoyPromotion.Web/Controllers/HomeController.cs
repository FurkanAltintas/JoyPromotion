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
            var models = new ContentListViewModel
            {
                Contents = _contentService.GetAll()
            };
            return View(models);
        }
    }
}
