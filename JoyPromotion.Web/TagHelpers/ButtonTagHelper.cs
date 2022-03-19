using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace JoyPromotion.Web.TagHelpers
{
    [HtmlTargetElement("btn-button")]
    public class ButtonTagHelper : TagHelper
    {
        [HtmlAttributeName("btn-value")]
        public string value { get; set; }

        [HtmlAttributeName("btn-type")]
        public string type { get; set; }

        [HtmlAttributeName("btn-class")]
        public string style { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat($"<button type'{type}' class='btn {style}'>{value}</button>");
            base.Process(context, output);  
        }
    }
}
