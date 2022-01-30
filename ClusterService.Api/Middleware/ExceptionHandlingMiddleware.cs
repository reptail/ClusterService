using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ClusterService.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IWebHostEnvironment env)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, env, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, IWebHostEnvironment env, Exception ex)
        {
            int statusCode = StatusCodes.Status500InternalServerError;
            string message = ex.Message;
            List<string> details = new();

            if (ex is ResponseException responseEx)
                statusCode = responseEx.StatusCode;

            if (env.IsDevelopment())
            {
                if (!string.IsNullOrWhiteSpace(ex.StackTrace))
                    details.Add(ex.StackTrace);

                if (ex.InnerException is not null)
                    details.Add(ex.InnerException.ToString());
            }

            dto.Error dtoError = new(ex.Message, details.ToArray());

            httpContext.Response.Clear();
            httpContext.Response.StatusCode = statusCode;

            return httpContext.Response.WriteAsJsonAsync(dtoError);
        }
    }

}
