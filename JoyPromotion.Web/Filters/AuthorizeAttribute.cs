using JoyPromotion.Shared.Enums;
using System;

namespace JoyPromotion.Web.Filters
{
    public class AuthorizeAttribute : Attribute
    {
        public string Roles { get; set; } = String.Format($"{RoleType.Admin}, {RoleType.Writer}");
    }
}
