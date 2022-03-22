using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace JoyPromotion.Web.TagHelpers
{
    [HtmlTargetElement("alert-count")]
    public class AlertCountTagHelper : TagHelper
    {

        [HtmlAttributeName("alert-message")]
        public string Message { get; set; }

        [HtmlAttributeName("alert-count")]
        public int Count { get; set; }

        [HtmlAttributeName("alert-color")]
        public string Color { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendFormat(@"<div class='alert alert-{0}' role='alert'>{1} {2}</div>", Color, Message, Count);
            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }
    }
}
