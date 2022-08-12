using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KretaWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KretaHelloController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public KretaHelloController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("api/hello", Name = "Kréta helló")]
        public IActionResult GetData()
        {
            string result = "Hello Kréta!";
            return Ok(result);
        }
    }
}
