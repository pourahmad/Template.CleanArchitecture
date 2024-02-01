using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Template.CleanArchitecture.Api.Middlewares
{
    public class CorsAccessControllMiddleware
    {
        private readonly RequestDelegate _next;
        public CorsAccessControllMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var user = httpContext.User;

            string origin = "http://localhost:61949";
            string headers = "Content-Type, Accept, X-Requested-With";
            string mehtods = "Get, Post";
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", origin);
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", headers);
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", mehtods);

            if(httpContext.Request.Method == "GET")
            {
                httpContext.Response.StatusCode = StatusCodes.Status200OK;

                return Task.CompletedTask;
            }

            return _next(httpContext);
        }
    }
    public static class AccessControllCorsMiddlewareExtensions
    {
        public static IApplicationBuilder UseCorsAccessControllMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorsAccessControllMiddleware>();
        }
    }
}
