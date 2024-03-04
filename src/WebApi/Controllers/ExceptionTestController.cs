using ExceptionalWebApi.Exceptions;
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

        [HttpPost("{statusCode}")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetHttpResponseByStatusCode([FromRoute]HttpStatusCode statusCode, [FromBody] object? returnPayload)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(new ValidationProblemDetails());

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
    }
}
