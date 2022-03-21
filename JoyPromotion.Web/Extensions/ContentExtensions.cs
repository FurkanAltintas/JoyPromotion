namespace JoyPromotion.Web.Extensions
{
    public static class ContentExtensions
    {
        public static string DescriptionSubstring(string description, int number = 150)
        {
            description = (description.Length < number
                ? description
                : description.Substring(0, description.Substring(0, number).LastIndexOf(" ")));
            return description;
        }
    }
}
