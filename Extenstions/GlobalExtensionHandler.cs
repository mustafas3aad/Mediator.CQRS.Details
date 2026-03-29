using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace Mediator.CQRS.Extenstions
{
    public static class GlobalExtensionHandler
    {
        public static void HandleException(this IApplicationBuilder app)
        {
            // Note:
            // This middleware will catch any unhandled exceptions that occur during the request processing
            // and return a generic error response to the client.
            app.UseExceptionHandler(e=>
            e.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                //Note:
                // If the exception is not a ValidationException, rethrow it to be handled by the global exception handler
                // not related to request validation.
                if ( !(exception is ValidationException validationException))
                    throw exception;

                //Note:
                // If the exception is a ValidationException, return a 400 Bad Request response with the validation errors.
                var errors = validationException.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                var errorCount = JsonSerializer.Serialize(errors);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode =(int) StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(errorCount,System.Text.Encoding.UTF8);
                return;


            }));
        }
    }
}
