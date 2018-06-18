using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Food
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Singleton creates one service class to be used throughout the project
            services.AddSingleton<IGreeter, Greeter>();
            // Scoped creates a new service class for each request
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();

            // Required to use MVC middleware
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env, 
                              IGreeter greeter, 
                              ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                // Use verbose exceptions when in development
                app.UseDeveloperExceptionPage();
            }

            app.UseWelcomePage(new WelcomePageOptions
            {
                Path="/welcome"
            });

            // app.UseFileServer(); => combos UseDefeultFile & UseStaticFiles()

            // If user directly accesses static file (e.g. /index.html), serve it, otherwise...
            app.UseStaticFiles();

            // Serve MVC routes
            // Requires MVC service
            app.UseMvc(ConfigureRoutes);


            app.Run(async (context) =>
            {
                string greeting = greeter.GetMessage();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName}");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index/maybeSomeId
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
