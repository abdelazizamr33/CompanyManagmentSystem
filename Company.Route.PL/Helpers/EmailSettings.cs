using System.Net;
using System.Net.Mail;

namespace Company.Route.PL.Helpers
{
    public static class EmailSettings
    {
        public static bool SendEmail(Email email)
        {
            // Mail Server "gmail"
            // Email Protocol : SMTP
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("zizoamr920@gmail.com", "gnbgaurlvviwspmu"); //Sender
                client.Send("zizoamr920@gmail.com", email.To, email.Subject, email.Body);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
