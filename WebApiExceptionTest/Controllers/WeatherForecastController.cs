using Microsoft.AspNetCore.Mvc;

namespace WebApiExceptionTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExceptionTest : ControllerBase
    {
        private readonly ILogger<ExceptionTest> _logger;

        public ExceptionTest(ILogger<ExceptionTest> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IEnumerable<WeatherForecast> Get()
        {
            
        }
    }
}
