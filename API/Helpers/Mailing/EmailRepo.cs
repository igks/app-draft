//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Mailing implementation
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Hosting;
using MimeKit;

namespace API.Helpers.Mailing
{
    public class EmailContent
    {
        public string ReceiverName { get; set; }
        public string ReceiverEmail { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string RedirectUrl { get; set; }
    }

    public class EmailRepo : IEmailRepo
    {
        private readonly IEmailSender _sender;
        private readonly IHostEnvironment _env;

        public EmailRepo(IEmailSender emailSender, IHostEnvironment env)
        {
            _sender = emailSender;
            _env = env;
        }
        public void SendNotification(EmailContent content)
        {
            var webRoot = _env.ContentRootPath;
            var pathToFile = _env.ContentRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "wwwroot"
                            + Path.DirectorySeparatorChar.ToString()
                            + "mail-templates"
                            + Path.DirectorySeparatorChar.ToString()
                            + "notification.html";
            var builder = new BodyBuilder();

            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            string messageBody = string.Format(builder.HtmlBody,
                        content.ReceiverName,
                        content.Content1,
                        content.Content2,
                        content.RedirectUrl
                        );
            var task = Task.Run(async () => await _sender.SendEmailAsync(content.ReceiverEmail, "Example Email Service Notification", messageBody));
        }
    }
}