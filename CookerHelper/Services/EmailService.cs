using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CookerHelper.Services
{
    public class EmailService
    {
        public async void SendEmailAsync(string email, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("semenplujara@gmail.com");
            mail.To.Add(email);
            mail.Subject = "Forgot password";
            mail.IsBodyHtml = true;
            mail.Body = message;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("semenplujara@gmail.com", "Qwerty1-"),
                EnableSsl = true
            };

            await Task.Run(() => {
                client.Send(mail);
            });
        }
    }
}
