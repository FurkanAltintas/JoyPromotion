using Microsoft.AspNetCore.Mvc;

namespace JoyPromotion.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
