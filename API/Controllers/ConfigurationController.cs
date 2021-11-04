//===================================================
// Date         : 
// Author       : I Gusti Kade Sugiantara
// Description  : Configuration controller
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly SystemConfig _systemConfig;

        public ConfigurationController(IOptions<SystemConfig> systemConfig)
        {
            _systemConfig = systemConfig.Value;
        }

        [HttpGet]
        public IActionResult GetVersion()
        {
            var version = _systemConfig.Version;
            return Ok(version);
        }
    }
}
