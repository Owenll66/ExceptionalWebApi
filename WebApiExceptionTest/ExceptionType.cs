namespace WebApiExceptionTest
{
    public enum ExceptionType
    {
        InvalidException, // 400
        UnauthorizedException, // 401
        PaymentRquiredException, // 402
        ForbiddenException, // 403
        NotFoundException, // 404
        InternalServerException // 500
    }
}
