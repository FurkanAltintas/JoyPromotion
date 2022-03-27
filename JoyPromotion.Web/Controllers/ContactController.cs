using JoyPromotion.Business.Abstract;
using JoyPromotion.Shared.Utils.Security.Captcha;
using JoyPromotion.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace JoyPromotion.Web.Controllers
{
    public class ContactController : Controller
    {
        private const string CaptchaCode = "CaptchaCode";
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [Route("get-captcha-image")]
        public IActionResult GetCaptchaImage()
        {
            int width = 100;
            int height = 36;
            var captchaCode = Captcha.GenerateCaptchaCode();
            var result = Captcha.GenerateCaptchaImage(width, height, captchaCode);
            HttpContext.Session.SetString(CaptchaCode, result.CaptchaCode);
            Stream stream = new MemoryStream(result.CaptchaByteData);
            return new FileStreamResult(stream, "image/png");
        }

        public IActionResult Index()
        {
            return View(new ContactAddViewModel());
        }

        [HttpPost]
        public IActionResult Index(ContactAddViewModel contactAddViewModel)
        {
            if (ModelState.IsValid)
            {
                if (Captcha.ValidateCaptchaCode(contactAddViewModel.ContactAddDto.CaptchaCode, HttpContext))
                {
                    _contactService.Add(contactAddViewModel.ContactAddDto);
                    return RedirectToAction("Index","Home");
                }

                ModelState.AddModelError(string.Empty, "The captcha information you entered is incorrect.");
            }

            return View(contactAddViewModel);
        }
    }
}
