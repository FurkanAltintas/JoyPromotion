using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoyPromotion.Web.TagHelpers
{
    [HtmlTargetElement("random-color-badge")]
    public class RandomColorBadgeTagHelper : TagHelper
    {
        [HtmlAttributeName("rcb-value")]
        public string value { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<string> colors = new() { "success", "primary", "danger", "warning", "dark" };
            Random random = new Random();

            StringBuilder stringBuilder = new();
            stringBuilder.AppendFormat($"<i class='badge bg-{colors[RandomColor(random, colors)]}'>{value}</i>");
            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }

        public int RandomColor(Random random, List<string> colors)
        {
            return random.Next(0, colors.Count);
        }
    }
}
