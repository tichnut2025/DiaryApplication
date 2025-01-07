using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;

namespace API
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CultureMiddleware
    {
        //private readonly RequestDelegate _next;

        //public RequestCultureMiddleware(RequestDelegate next)
        //{
        //    _next = next;
        //}

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    var cultureQuery = context.Request.Query["culture"];
        //    if (!string.IsNullOrWhiteSpace(cultureQuery))
        //    {
        //        var culture = new CultureInfo(cultureQuery);

        //        CultureInfo.CurrentCulture = culture;
        //        CultureInfo.CurrentUICulture = culture;
        //    }

        //    // Call the next delegate/middleware in the pipeline.
        //    await _next(context);
        //}

        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var cultureQuery = httpContext.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);
                if (cultureQuery == "ar-sa")
                {
                    httpContext.Response.StatusCode = 403; // Forbidden
                      httpContext.Response.WriteAsync("הגישה אסורה מארצות ערב.");
                }
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            //    // Call the next delegate/middleware in the pipeline.
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseCultureMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddleware>();
        }
    }
}
