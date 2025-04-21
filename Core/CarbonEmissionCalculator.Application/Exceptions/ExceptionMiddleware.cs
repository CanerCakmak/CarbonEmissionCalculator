using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace CarbonEmissionCalculator.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpcontext, RequestDelegate next)
        {
            try
            {
                await next(httpcontext);
            }
            catch (Exception ex)
            {
                await HandleExeptionAsync(httpcontext, ex);
            }
        }

        private static Task HandleExeptionAsync(HttpContext httpcontext, Exception exception)
        {
            int statuscode = GetStatusCode(exception);
            httpcontext.Response.ContentType = "application/json";
            httpcontext.Response.StatusCode = statuscode;

            if (exception.GetType() == typeof(ValidationException))
                return httpcontext.Response.WriteAsync(new ExceptionModel
                {
                    Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage),
                    StatusCode = StatusCodes.Status400BadRequest
                }.ToString());

            List<string> errors = new List<string>()
            {
                $"Hata Mesajı :{exception.Message}"
            };

            return httpcontext.Response.WriteAsync(new ExceptionModel
            {
                Errors = errors,
                StatusCode = statuscode
            }.ToString());
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status400BadRequest,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };

    }
}
