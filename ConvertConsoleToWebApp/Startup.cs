using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ConvertConsoleToWebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllerRoute(
                   name: "default",
                   pattern:"{controller=Home}/{action=Index}/{id?}"
                   ) ;
           });

        }


    }
}