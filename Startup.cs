using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace aspnetcorestatic
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app,IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            var logger = loggerFactory.CreateLogger("custom middleware");

            app.UseStaticFiles();

            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            //custom middleware
            app.Use(async (context, next) =>
            {
                logger.LogInformation("Handling request.");
                await next.Invoke();
                logger.LogInformation("Finished handling request.");
            });

            //custom middleware using class
            app.UseRequestLogger();

            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello from ASP.NET Core!");
            });
        }
    }
}