//===================================================
// Date         : 
// Author       : I Gusti Kade Sugiantara
// Description  : Mail controller
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System.Threading.Tasks;
using API.Helpers.Mailing;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MailController : ControllerBase
    {
        private readonly IEmailRepo _emailRepo;

        public MailController(IEmailRepo emailRepo)
        {
            _emailRepo = emailRepo;
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            var content = new EmailContent
            {
                ReceiverName = "User Name",
                ReceiverEmail = "IGustiKade.Sugiantara@alcon.com",
                Content1 = "Content 1",
                Content2 = "Content 2",
                RedirectUrl = "https://www.google.com"
            };

            BackgroundJob.Enqueue(
                  () => _emailRepo.SendNotification(content)
            );
            return Ok();
        }
    }
}