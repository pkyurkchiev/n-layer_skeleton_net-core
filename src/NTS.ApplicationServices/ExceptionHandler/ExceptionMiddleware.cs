using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace NTS.ApplicationServices.ExceptionHandler
{
    using Enums;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Utils.Extensions;

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception.Message == BusinessExceptionEnum.NotFoundException.GetDescription()) code = HttpStatusCode.NotFound;
            else if (exception.Message == BusinessExceptionEnum.BadRequestException.GetDescription()) code = HttpStatusCode.BadRequest;

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
