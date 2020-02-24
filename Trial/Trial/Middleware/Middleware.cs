using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Trial.Middleware
{
    public class MyMiddleware
    {
        // Attributes
        private readonly RequestDelegate _next;

        // Constructor of Class
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            Console.WriteLine(context.Response.StatusCode);
            if (context.Response.StatusCode == 404)
            {
                Console.WriteLine("Status Code : {0}", context.Response.StatusCode);
            }
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}
