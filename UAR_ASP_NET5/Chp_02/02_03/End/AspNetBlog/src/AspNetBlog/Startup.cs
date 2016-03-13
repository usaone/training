﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

namespace AspNetBlog
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.StartsWith("/hello"))
                {
                    await context.Response.WriteAsync("How are you?");
                }
                await next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello ASP.NET 5!");
            });

        }
    }
}
