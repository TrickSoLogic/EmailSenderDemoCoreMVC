using System.Net;
using System.Net.Mail;

namespace EmailSenderDemoCoreMVC
{
    public class Sendmail
    {
        public static void Email(string to,string subject, string body)
        {
            MailMessage mm = new();
            mm.To.Add(new MailAddress(to));
            mm.From = new MailAddress("youremail@gmail.com");
            mm.Subject = subject;   
            mm.Body = body;
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            SmtpClient smtpClient = new();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl= true;
            smtpClient.Credentials = new NetworkCredential("youremail@gmail.com", "app_password generated from SMTP server provider");
            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtpClient.Send(mm);
            
            }
      
    }
}

