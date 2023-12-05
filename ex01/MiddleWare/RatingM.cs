using Entities;
using Entytess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using servies;
using System.Threading.Tasks;

namespace project.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingM
    {
        private readonly RequestDelegate _next;


        public RatingM(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingService rating)
        {
            Rating r = new Rating();
            DateTime Date = DateTime.Now;

           
            r.Host = httpContext.Request.Host.ToString();
            r.Method = httpContext.Request.Method;
            r.Path = httpContext.Request.Path;
            r.Referer = httpContext.Request.Headers["Referer"].ToString();
            r.UserAgent = httpContext.Request.Headers["User-Agent"].ToString();
            r.RecordDate = Date;
            rating.AddRating(r); 
            _next(httpContext);






        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingM>();
        }
    }
}
