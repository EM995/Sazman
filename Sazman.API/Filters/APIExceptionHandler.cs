using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Sazman.API.Filters
{
    public class APIExceptionHandler : IExceptionHandler
    {
        public void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = context.Exception.Message;
            //var exceptionType = context.Exception.GetType();
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            var err = message + " " + context.Exception.StackTrace;
            response.WriteAsync(err);
        }
    }
}
