//===================================================
// Date         : 05 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Email service
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using API.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;

namespace API.Helpers.Mailing
{
    public class EmailSenderService : IEmailSender, IHostedService, IDisposable
    {
        private readonly BufferBlock<MimeMessage> _mailMessages;
        private readonly SmtpConfig _smtp;
        private Task sendTask;
        private CancellationTokenSource cancellationTokenSource;

        public EmailSenderService(IConfiguration configuration, IOptions<SmtpConfig> smtp)
        {
            _mailMessages = new BufferBlock<MimeMessage>();
            _smtp = smtp.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_smtp.Sender));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;
            message.Body = new TextPart("html")
            {
                Text = htmlMessage
            };

            await _mailMessages.SendAsync(message);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            cancellationTokenSource = new CancellationTokenSource();
            // The StartAsync method just needs to start a background task (or a timer)
            sendTask = DeliverAsync(cancellationTokenSource.Token);
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            //Let's cancel the e-mail delivery
            CancelSendTask();
            //Next, we wait for sendTask to end, but no longer than what the web host allows
            await Task.WhenAny(sendTask, Task.Delay(Timeout.Infinite, cancellationToken));
        }

        private void CancelSendTask()
        {
            try
            {
                if (cancellationTokenSource != null)
                {
                    cancellationTokenSource.Cancel();
                    cancellationTokenSource = null;
                }
            }
            catch
            {

            }
        }

        public async Task DeliverAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                MimeMessage message = null;
                try
                {
                    // Let's wait for a message to appear in the queue
                    // If the token gets canceled, then we'll stop waiting
                    // since an OperationCanceledException will be thrown
                    message = await _mailMessages.ReceiveAsync(token);

                    // As soon as a message is available, we'll send it
                    using var client = new SmtpClient();
                    await client.ConnectAsync(_smtp.Host, _smtp.Port, _smtp.Security);

                    if (!string.IsNullOrEmpty(_smtp.Username))
                    {
                        await client.AuthenticateAsync(_smtp.Username, _smtp.Password);
                    }
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                catch (OperationCanceledException)
                {
                    // We need to terminate the delivery, so we'll just break the while loop
                    break;
                }
                catch
                {
                    // Just wait a second, perhaps the mail server was busy
                    await Task.Delay(1000);
                    // Then re-queue this email for later delivery
                    await _mailMessages.SendAsync(message);

                }
            }
        }

        public void Dispose()
        {
            CancelSendTask();
        }
    }
}