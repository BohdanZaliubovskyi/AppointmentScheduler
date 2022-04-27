using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient("3825c28514dca244d1311dee6af2fc99", "5080d485af149f8a54d7f3da3a3ab9bb")
            { };

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
           .Property(Send.FromEmail, "komvariant@gmail.com")
           .Property(Send.FromName, "Appointment Scheduler")
           .Property(Send.Subject, subject)
           .Property(Send.HtmlPart, htmlMessage)
           .Property(Send.Recipients, new JArray {
                new JObject {
                 {"Email", /*email*/"komvariant@gmail.com"}
                 }
               });
            MailjetResponse response = await client.PostAsync(request);

            //MailjetRequest request = new MailjetRequest
            //{
            //    Resource = Send.Resource,
            //}
            //   .Property(Send.Messages, new JArray {
            //    new JObject {
            //     {"From", new JObject {
            //      {"Email", "komvariant@gmail.com"},
            //      {"Name", "Appointment scheduler"}
            //      }},
            //     {"To", new JArray {
            //      new JObject {
            //       {"Email", email},
            //       {"Name", "You"}
            //       }
            //      }},
            //     {"Subject", subject},
            //     {"TextPart", "Empty"},
            //     {"HTMLPart", htmlMessage}
            //     }
            //       });
            //MailjetResponse response = await client.PostAsync(request);
        }
    }
}
