using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace JoyPromotion.Web.Extensions
{
    public static class UserExtensions
    {
        public static int UserKey(this Controller controller)
        {
            return int.Parse((controller.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)).Value);
        }

        public static string UserName(this Controller controller)
        {
            return controller.User.Identity.Name;
        }
    }
}
