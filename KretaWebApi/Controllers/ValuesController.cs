using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KretaWebApi.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class Values2Controller : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public Values2Controller(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetData()
        {
            string result = "A";
            return Ok(result);
        }
    }
}
