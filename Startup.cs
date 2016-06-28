using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace aspnetcorestatic
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello from ASP.NET Core!");
            });
        }
    }
}