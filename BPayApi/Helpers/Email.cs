using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using RestSharp;
using RestSharp.Authenticators;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BPayApi.Helpers
{
    public static class Email
    {
        public static string Send(string Receiver, string ReceiverEmail, string Subject, string Body)
        {

            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("BPay App", "bpay@bellokano.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(Receiver, ReceiverEmail);
            message.To.Add(to);

            message.Subject = Subject;

            BodyBuilder bodyBuilder = new BodyBuilder
            {
                HtmlBody = Body,
                TextBody = Body
            };

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("bellokano.com", 465);//, false);
            client.Authenticate("bpay@bellokano.com", "secured@Bpay");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return "";
        }

        public static async Task SendGrid()
        {
            var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient("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");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("kmn.knowmyneighbor@gmail.com", "B Pay App"),
                Subject = "Hello World from the SendGrid CSharp SDK!",
                PlainTextContent = "Hello, Email!",
                HtmlContent = "<strong>Hello, Email!</strong>"
            };
            msg.AddTo(new EmailAddress("olaniyiolatunji@gmail.com", "Test User"));
            var response = await client.SendEmailAsync(msg);
          //  return response;
        }
    }
}