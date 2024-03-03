using ExceptionalWebApi.Exceptions;
using ExceptionTestWebApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
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
                    throw new InvalidRequestException(BadRequest());

                case ExceptionType.UnauthorizedException:
                    throw new UnauthorizedException("Unauthorized request");

                case ExceptionType.ForbiddenException:
                    throw new ForbiddenException(new { Prop1 = "Prop1", Prop2 = "Prop2" });

                case ExceptionType.NotFoundException:
                    throw new NotFoundException();

                case ExceptionType.InternalServerException:
                    throw new InternalServerException();

                default:
                    return Ok();
            }
        }

        [HttpPost("requestValidation")]
        public IActionResult RquestValidation([FromBody] RequestsForValidations request)
        {
            return Ok();
        }
    }
}
