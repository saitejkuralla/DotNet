using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Utility
{
    public static class CustomAuthorization
    {
        public static IApplicationBuilder UseCustomAuthorize(this IApplicationBuilder app)
        {
            //app.Use(async (context,next) =>
            //{
            //     context.Request.Headers.ContainsKey("auth").ToString();

            //    await
            //})

            return app.UseMiddleware<MyMiddleware>();
        }

    }


    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
       

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;

           
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var authValue = httpContext.Request.Headers.ContainsKey("auth").ToString();
            if(authValue=="saitej")
            {
                await _next(httpContext);

            }

            httpContext.Response.StatusCode = 401;
        }
    }
}
