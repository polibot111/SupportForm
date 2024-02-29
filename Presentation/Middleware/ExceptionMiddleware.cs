using DataAccess.Wrapper;
using System.Net;
using System.Text.Json;

namespace Presentation.Middleware
{
    public class ExceptionMiddleware
    {
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private readonly RequestDelegate _next;
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                string errorMessage = error.Message;
                string stackTrace = error.StackTrace;

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var responseModel = new Response<string>
                {
                    Succeeded = false,
                    Message = $"An error occurred in the system! Please try again later.",
                    Errors = new List<Dictionary<string, string>>
                {
                    new Dictionary<string, string>
                    {
                        { "ErrorMessage", errorMessage }
                    }
                }
                };

                var result = JsonSerializer.Serialize(responseModel);
                await context.Response.WriteAsync(result);
            }
        }
    }
}
