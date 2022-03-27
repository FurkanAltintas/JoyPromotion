namespace JoyPromotion.Shared.Extensions
{
    public static class UserNameExtensions
    {
        public static string UserName(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return "";
            userName = userName.ToLower();
            userName = userName.Trim();
            userName = userName.Replace("İ", "I");
            userName = userName.Replace("ı", "i");
            userName = userName.Replace("ğ", "g");
            userName = userName.Replace("Ğ", "G");
            userName = userName.Replace("ç", "c");
            userName = userName.Replace("Ç", "C");
            userName = userName.Replace("ö", "o");
            userName = userName.Replace("Ö", "O");
            userName = userName.Replace("ş", "s");
            userName = userName.Replace("Ş", "S");
            userName = userName.Replace("ü", "u");
            userName = userName.Replace("Ü", "U");
            return userName;
        }
    }
}
