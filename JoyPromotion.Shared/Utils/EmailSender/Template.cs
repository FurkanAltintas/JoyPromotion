namespace JoyPromotion.Shared.Utils.EmailSender
{
    public class Template
    {
        public string EmailConfirmed(string baseUrl)
        {
            return new string(@$"
            <div style='position: relative; margin: auto; background-color: #fff; width: 450px; padding: 50px;'>
                <p>Merhaba,</p>
                <p>Joy hesabını aktifleştirmek için lütfen <a href='{baseUrl}' target='_blank'>buraya</a> tıkla.</p>
                <p> Saygılarımızla,</p>
                <p>Joy Ekibi</p>
            </div>");
        }

        public string PasswordReset(string baseUrl)
        {
            return string.Format(@$"
            <div style='position: relative; margin: auto; background-color: #fff; width: 450px; padding: 50px;'>
                <p>Merhaba,</p>
                <p>Joy hesap şifresini değiştirmek için lütfen <a href='{baseUrl}' target='_blank'>buraya</a> tıkla.</p>
                <br>
                <p><strong>Bu siz değilseniz:</strong></p>
                <p>Joy hesabınızı başkalarınca ele geçirilmiş olabilir. Hesabınızın güvenliğini sağlamak için yapmanız gereken şeyler var.
                Başlangıç olarak, lütfen parolanızı hemen sıfırlayın.</p>
                <p>Saygılarımızla,</p>
                <p>Joy Ekibi</p>
            </div>");
        }
    }
}
