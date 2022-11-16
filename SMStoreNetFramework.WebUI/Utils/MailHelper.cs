using SMStore.Entities;
using System;
using System.Net;
using System.Net.Mail;

namespace SMStoreNetFramework.WebUI.Utils
{
	public class MailHelper
    {
        public static bool SendMail(Contact contact)
        {
			try
			{
				SmtpClient client = new SmtpClient("mail.siteadi.com", 587); // 1 smtp kullanıcısı oluşturup buraya parametreyle sunucu bilgilerimizi gönderiyoruz
				client.Credentials = new NetworkCredential("mail kullanıcı adı", "mail şifresi");
				client.EnableSsl = true; // eğer mail sunucuda ssl sertifikası kullanılıyorsa

				MailMessage message = new MailMessage();
				message.From = new MailAddress("info@siteadi.com");
				message.To.Add("info@siteadi.com"); // mesajın gönderileceği adres
                message.To.Add("info@siteadi.com"); // kaç yere göndermek istersek ekleyebiliriz
				message.Subject = "Siteden Mesaj Var"; // Mailde konu kısmında görünecek bilgi
				message.Body = $"<p>İsim : {contact.Name} {contact.Surname}</p> <p>Email : {contact.Email}</p> <p>Telefon : {contact.Phone}</p> <p>Mesaj : {contact.Message}</p>";
                message.IsBodyHtml = true; // Mailde html formatını aktif ediyoruz, Html.Raw gibi

                client.Send(message); // email kullanıcı bilgilerimizi kullanarak mesajı mail olarak gönder

                return true;
			}
			catch (Exception hata)
			{
				// todo: burada hata oluşursa yakalyıp veritabanına kaydedebiliriz.
				return false;
			}
        }
    }
}