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
        public IActionResult GetHttpResponseByStatusCode([FromRoute]HttpStatusCode statusCode, [FromBody] object? payload = null)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    if (payload != null)
                        throw new BadRequestException(payload, 400);

                    throw new BadRequestException();

                case HttpStatusCode.Unauthorized:
                    if (payload != null)
                        throw new UnauthorizedException(payload, 401);

                    throw new BadRequestException();

                case HttpStatusCode.Forbidden:
                    if (payload != null)
                        throw new ForbiddenException(payload, 403);

                    throw new ForbiddenException();

                case HttpStatusCode.NotFound:
                    if (payload != null)
                        throw new NotFoundException(payload, 404);

                    throw new NotFoundException();

                case HttpStatusCode.InternalServerError:
                    if (payload != null)
                        throw new InternalServerErrorException(payload, 500);

                    throw new InternalServerErrorException();

                default:
                    return Ok();
            }
        }
    }
}
