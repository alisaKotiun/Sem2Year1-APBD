using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Tutorial9.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception exc)
            {
                using (StreamWriter sw = File.AppendText("logs.txt"))
                {
                    await sw.WriteLineAsync(new ErrorInfo()
                    {
                        Message = exc.Message,
                        Date = DateTime.Now
                    }.ToString());
                }
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync(exc.Message);
            }
        }
    }
}
