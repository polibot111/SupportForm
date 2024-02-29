using System.Text.Json;
using System.Text;
using DataAccess.Wrapper;

namespace Presentation.Middleware
{
    public class ResponseWrapperMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseWrapperMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalBody = context.Response.Body;

            try
            {
                using (var memoryStream = new MemoryStream())
                {

                    context.Response.Body = memoryStream;

                    await _next(context);


                    memoryStream.Seek(0, SeekOrigin.Begin);
                    string responseBody = await new StreamReader(memoryStream).ReadToEndAsync();


                    if (context.Response.ContentType?.ToLower().Contains("application/json") == true)
                    {

                        var responseModel = new Response<object>
                        {
                            Data = JsonSerializer.Deserialize<object>(responseBody),
                            Succeeded = context.Response.StatusCode >= 200 && context.Response.StatusCode < 300,
                            Message = context.Response.StatusCode >= 200 && context.Response.StatusCode < 300 ? "Success" : "Failed",
                            Errors = null
                        };


                        string jsonResponse = JsonSerializer.Serialize(responseModel);

                        context.Response.Body = originalBody;

                        context.Response.ContentType = "application/json";
                        context.Response.ContentLength = Encoding.UTF8.GetByteCount(jsonResponse);
                        await context.Response.WriteAsync(jsonResponse);
                    }
                }
            }
            finally
            {
                context.Response.Body = originalBody;
            }

        }
    }
}
