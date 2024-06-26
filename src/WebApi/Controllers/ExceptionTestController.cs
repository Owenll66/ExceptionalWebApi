using ExceptionalWebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("exceptions")]
    public class ExceptionTestController : ControllerBase
    {
        private readonly ILogger<ExceptionTestController> _logger;

        public ExceptionTestController(ILogger<ExceptionTestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{statusCode}")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetHttpResponseByStatusCode([FromRoute]HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException();

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException();

                case HttpStatusCode.Forbidden:
                    throw new ForbiddenException();

                case HttpStatusCode.NotFound:
                    throw new NotFoundException();

                case HttpStatusCode.InternalServerError:
                    throw new InternalServerErrorException();

                case HttpStatusCode.PaymentRequired:
                    throw new CustomException();

                default:
                    throw new Exception();
            }
        }
    }
}
