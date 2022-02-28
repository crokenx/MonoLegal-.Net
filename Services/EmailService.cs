using System;
using System.Text;
using System.Net.Mail;

namespace ApiNetCoreMonoLegal.Services
{
    public class EmailService
    {
        public void SendEmail(string text, string to)
        {
            string from = "quesadadiaz18@gmail.com";
            MailMessage message = new MailMessage(from, to);

            message.Subject = "Correo de prueba para MonoLegal SAS, usando Api .Net";
            message.Body = text;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            System.Net.NetworkCredential basicCredential = new
                System.Net.NetworkCredential("quesadadiaz18@gmail.com", "wdrsiwvlthxehfao");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential;
            try
            {
                client.Send(message);
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
