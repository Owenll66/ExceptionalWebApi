using ExceptionalWebApi.Exceptions;
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
        public IActionResult Get(ExceptionType exceptionType)
        {
            switch (exceptionType)
            {
                case ExceptionType.InvalidException:
                    throw new InvalidException();

                case ExceptionType.UnauthorizedException:
                    throw new InvalidException();

                case ExceptionType.PaymentRquiredException:
                    throw new InvalidException();

                case ExceptionType.ForbiddenException:
                    throw new InvalidException();

                case ExceptionType.NotFoundException:
                    throw new InvalidException();

                case ExceptionType.InternalServerException:
                    throw new InvalidException();

                default:
                    return Ok();
            }
        }
    }
}
