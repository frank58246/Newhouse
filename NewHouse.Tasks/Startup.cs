using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newhouse.DependencyInjection;
using NewHouse.Common.Helper;
using NewHouse.Tasks.Infracture.DependencyInjection;
using NewHouse.Tasks.Infracture.Jobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace NewHouse.Tasks
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
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var assemblies = new[]
            {
                 Assembly.LoadFrom($"{baseDirectory}NewHouse.Service.dll"),
                 Assembly.LoadFrom($"{baseDirectory}NewHouse.Common.dll"),
                 Assembly.LoadFrom($"{baseDirectory}NewHouse.Repository.dll"),
                 Assembly.LoadFrom($"{baseDirectory}NewHouse.Tasks.dll")
            };

            services.Scan(scan =>
                scan.FromAssemblies(assemblies)
                    .AddClasses()
                    .AsMatchingInterface()
                    );

            services.AddCommonDependencyInjection(Configuration);

            services.AddControllersWithViews();

            services.AddHangfire();

            services.AddMapping();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Hangfire
            var hangfireOption = new BackgroundJobServerOptions
            {
                WorkerCount = Environment.ProcessorCount * 20,
              
                
            };
            
            app.UseHangfireServer(hangfireOption);
            app.UseHangfireDashboard("/hangfire",
                                     new DashboardOptions
                                     {
                                         //預設授權無法在線上環境使用 Hangfire.Dashboard.LocalRequestsOnlyAuthorizationFilter
                                         //Authorization = new[] { new DashboardAuthorizationFilter() }

                                         //AppPath = System.Web.VirtualPathUtility.ToAbsolute("~/"),
                                         //DisplayStorageConnectionString = false,
                                         //IsReadOnlyFunc = f => true
                                     }
           );
        }
    }
}