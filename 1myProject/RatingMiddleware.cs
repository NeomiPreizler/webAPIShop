using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using DL;
using Entities;

namespace _1myProject
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext, IRatingDL ratingDL) {

            Rating rate = new();
            rate.Host = httpContext.Request.Host.Host;
            rate.Method = httpContext.Request.Method;
            rate.Path = httpContext.Request.Path;
            rate.Referer = httpContext.Request.Headers.Referer;
            rate.UserAgent = httpContext.Request.Headers.UserAgent;
            rate.RecordDate = DateTime.Now;

            await ratingDL.AddRating(rate);

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
