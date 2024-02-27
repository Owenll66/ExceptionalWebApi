using ExceptionalWebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

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

        [HttpGet("test/{exceptionType}")]
        public IActionResult GetTest(ExceptionType exceptionType)
        {
            switch (exceptionType)
            {
                case ExceptionType.InvalidRequestException:
                    return BadRequest();

                case ExceptionType.UnauthorizedException:
                    return Unauthorized();

                case ExceptionType.ForbiddenException:
                    return Forbid();

                case ExceptionType.NotFoundException:
                    return NotFound();

                case ExceptionType.InternalServerException:
                    return StatusCode(500);

                default:
                    return Ok();
            }
        }

        [HttpGet("{exceptionType}")]
        public IActionResult Get(ExceptionType exceptionType)
        {
            switch (exceptionType)
            {
                case ExceptionType.InvalidRequestException:
                    throw new InvalidRequestException(new Point(1,1));

                case ExceptionType.UnauthorizedException:
                    throw new UnauthorizedException();

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
