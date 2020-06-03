using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.EmailServices
{
    public class EmailSender : IEmailSender
    {
        // Our private configuration variables
        private const string SendGridKey = "";

        //private string host;
        //private int port;
        //private bool enableSSL;
        //private string userName;
        //private string password;

        // Get our parameterized configuration
        //public EmailSender(string host, int port, bool enableSSL, string userName, string password)
        //{
        //    this.host = host;
        //    this.port = port;
        //    this.enableSSL = enableSSL;
        //    this.userName = userName;
        //    this.password = password;
        //}


        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            /*
                var client = new SmtpClient(host, port) {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(userName, email, subject, htmlMessage) { IsBodyHtml = true }
            );
             */
            return Execute(SendGridKey, subject, htmlMessage, email);
        }

        private Task Execute(string sendGridKey, string subject, string message, string email)
        {
            var client = new SendGridClient(sendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("emrah@emrahsemiz.com", "Shop App"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
