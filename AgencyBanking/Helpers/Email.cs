using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace AgencyBanking.Helpers
{
    public static class Email
    {
        public static string Send(string Receiver, string ReceiverEmail, string Subject, string Body)
        {

            //MimeMessage message = new MimeMessage();

            //MailboxAddress from = new MailboxAddress("KMN App", "noreply@kmn.com");
            //message.From.Add(from);

            //MailboxAddress to = new MailboxAddress(Receiver, ReceiverEmail);
            //message.To.Add(to);

            //message.Subject = Subject;

            //BodyBuilder bodyBuilder = new BodyBuilder
            //{
            //    HtmlBody = Body,
            //    TextBody = Body
            //};

            //message.Body = bodyBuilder.ToMessageBody();

            //SmtpClient client = new SmtpClient();
            //client.Connect("smtp.gmail.com", 587, false);//, false);
            //client.Authenticate("kmn.knowmyneighbour@gmail.com", "Okot@2020KMN");

            //client.Send(message);
            //client.Disconnect(true);
            //client.Dispose();

            return "";
        }
    }
}
