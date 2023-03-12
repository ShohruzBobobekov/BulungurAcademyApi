using BulungurAcademy.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace BulungurAcademy.Api.Middlewares;
public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context,
        [FromServices] ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException validationException)
        {
            logger.LogError(validationException,validationException.Message);

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            await HandleException(context: context, message: validationException.Message);
        }
        catch (NotFoundException notFoundException)
        {
            logger.LogError(notFoundException,notFoundException.Message);

            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            var serilizedMessage = JsonSerializer.Serialize(new
            {
                notFoundException.Message
            });

            await HandleException(context: context, message: serilizedMessage);
        }
        catch (Exception globaleException)
        {
            logger.LogError(globaleException,globaleException.Message);

            await HandleException(context: context, message: globaleException.Message);
        }
    }
    private async Task HandleException(HttpContext context, string message)
    {
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(message);
    }
}
