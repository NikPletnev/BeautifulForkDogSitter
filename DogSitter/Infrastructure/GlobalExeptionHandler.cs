using DogSitter.BLL.Exeptions;
using System.Net;
using System.Text.Json;

namespace DogSitter.API.Infrastructure
{
    public class GlobalExeptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExeptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AccessException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                await HandleExceptionAsync(context, HttpStatusCode.ServiceUnavailable, "Сервер недоступен");
            }
            catch (ServiceNotEnoughDataExeption ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }

        }

        private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode code, string message)
        {
            var result = JsonSerializer.Serialize(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsync(result);
        }
    }
}
