using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace AgencyBanking.Helpers
{
    public static class Email
    {
        public static string Send(string Receiver, string ReceiverEmail, string Subject, string Body)
        {

            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("BPay App", "noreply@kmn.com");
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
            client.Connect("smtp.gmail.com", 587, false);//, false);
            client.Authenticate("kmn.knowmyneighbour@gmail.com", "Okot@2020KMN");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return "";
        }

        public static async Task SendUsingRapidApiAsync(string Receiver, string ReceiverEmail, string Subject, string Body)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://rapidprod-sendgrid-v1.p.rapidapi.com/mail/send"),
                Headers =
    {
        { "x-rapidapi-key", "97549e4f58msh98aacc0b972d42ap133b4djsna2dfacdefc3e" },
        { "x-rapidapi-host", "rapidprod-sendgrid-v1.p.rapidapi.com" },
    },
                Content = new StringContent("{\n    \"personalizations\": [\n  {\n    \"to\": [\n  {\n                " +
                "    \"email\": \""+ReceiverEmail+"\"\n                }\n            ],\n   " +
                "         \"subject\": \""+Subject+"\"\n        }\n    ],\n    \"from\": {\n      " +
                "  \"email\": \"noreply@bpay.com\"\n    },\n    \"content\": [\n        {\n  " +
                "          \"type\": \"text/html\",\n            \"value\": \""+Body+"\"\n        }\n    ]\n}")
                {
                    Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}
