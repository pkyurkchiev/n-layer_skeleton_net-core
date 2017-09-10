namespace NTS.ApplicationServices.ExceptionHandler.Enums
{
    using System.ComponentModel;

    public enum BusinessExceptionEnum
    {
        [Description("Not Found Exception.")]
        NotFoundException = 1,
        [Description("Not Found Exception.")]
        BadRequestException = 2,
        [Description("Not Valide Object.")]
        NotValideObject = 3,
        [Description("Unauthorized Request.")]
        UnauthorizedException = 4,
        [Description("Internal Exception.")]
        InternalException = 5
    }

}
