using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings;
using System.Text;

namespace CoreWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //add middleware way 1:
            //app.Use((next) => {
            //    return (httpcontext) => {
            //        if (httpcontext.Request.Headers.TryGetValue("x-api-key", out StringValues key) && key.ToString() == "xxx")
            //        {
            //            httpcontext.Request.Headers.Add("validRequest", "true");
            //            return next(httpcontext);
            //        }
            //        else
            //        {
            //            httpcontext.Request.Headers.Add("validRequest", "false");
            //            httpcontext.Response.StatusCode = 401;
            //            string message = "missing x-api-key";
            //            var buff = UTF8Encoding.GetEncoding("utf-8").GetBytes(message);
            //            httpcontext.Response.Body.WriteAsync(buff);
            //            return Task.CompletedTask;
            //        }
            //    };
            //});
            //add middleware way 2:
            app.Use(async (context, next) =>
            {
                if (context.Request.Headers.TryGetValue("x-api-key", out StringValues key) && key.ToString() == "xxx")
                {
                    context.Request.Headers.Add("validRequest", "true");
                    await next.Invoke();
                }
                else
                {
                    context.Request.Headers.Add("validRequest", "false");
                    context.Response.StatusCode = 401;
                    string message = "missing x-api-key";
                    var buff = UTF8Encoding.GetEncoding("utf-8").GetBytes(message);
                    await context.Response.Body.WriteAsync(buff);
                }
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
