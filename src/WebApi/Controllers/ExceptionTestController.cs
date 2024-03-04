using ExceptionalWebApi.Exceptions;
using ExceptionTestWebApi.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("exceptions")]
    public class ExceptionController : ControllerBase
    {
        private readonly ILogger<ExceptionController> _logger;

        public ExceptionController(ILogger<ExceptionController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{exceptionType}")]
        public IActionResult GetTest(HttpStatusCode exceptionType)
        {
            switch (exceptionType)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest();

                case HttpStatusCode.Unauthorized:
                    return Unauthorized();

                case HttpStatusCode.Forbidden:
                    return Forbid();

                case HttpStatusCode.NotFound:
                    return NotFound();

                case HttpStatusCode.InternalServerError:
                    return StatusCode(500);

                default:
                    return Ok();
            }
        }

        [HttpPost("{statusCode}")]
        public IActionResult GetHttpResponseByStatusCode([FromRoute]HttpStatusCode statusCode, [FromBody] object? returnPayload)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(returnPayload);

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(returnPayload);

                case HttpStatusCode.Forbidden:
                    throw new ForbiddenException(returnPayload);

                case HttpStatusCode.NotFound:
                    throw new NotFoundException(returnPayload);

                case HttpStatusCode.InternalServerError:
                    throw new InternalServerException(returnPayload);

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
