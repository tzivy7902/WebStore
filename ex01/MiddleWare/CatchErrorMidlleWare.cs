using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace project.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CatchErrorMidlleWare
    {
        private readonly RequestDelegate _next;

        public CatchErrorMidlleWare(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CatchErrorMidlleWareExtensions
    {
        public static IApplicationBuilder UseCatchErrorMidlleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CatchErrorMidlleWare>();
        }
    }
}
