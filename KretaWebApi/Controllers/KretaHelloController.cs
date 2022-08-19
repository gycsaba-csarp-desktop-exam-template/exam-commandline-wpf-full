using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceKretaLogger;

namespace KretaWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KretaHelloController : ControllerBase
    {
        private readonly ILoggerManager logger;

        public KretaHelloController(ILoggerManager logger)
        {
            this.logger = logger;
        }

        [HttpGet("api/hello", Name = "Kréta helló")]
        public IActionResult GetData()
        {
            string result = "Hello Kréta!";
            return Ok(result);
        }
    }
}
