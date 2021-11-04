//===================================================
// Date         : 
// Author       : I Gusti Kade Sugiantara
// Description  : SPA controller
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SPAController : Controller
    {
        public IActionResult Index()
        {
            return File("~/index.html", "text/html");
        }
    }
}