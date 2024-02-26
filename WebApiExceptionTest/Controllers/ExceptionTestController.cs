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
                    throw new UnauthorizedException();

                case ExceptionType.PaymentRquiredException:
                    throw new PaymentRquiredException();

                case ExceptionType.ForbiddenException:
                    throw new ForbiddenException();

                case ExceptionType.NotFoundException:
                    throw new NotFoundException();

                case ExceptionType.InternalServerException:
                    throw new InternalServerException();

                default:
                    return Ok();
            }
        }
    }
}
