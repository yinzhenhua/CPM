using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMRepository;
using PMRepository.IRepositories;
using PMRepository.Repositories;
using PMService.Interfaces.CodeMapServices;
using PMService.Services.CodeMapServices;

namespace PMWeb
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Default"),
                                  b => b.MigrationsAssembly("PMAPI"));
            });
            services.AddScoped<IUnitOfWork<DataContext>, UnitOfWork<DataContext>>();
            services.AddScoped<IRepository4CodeMap, Repository4CodeMap<DataContext>>();
            services.AddScoped<IAddService4CodeMap, ModifyService4CodeMap>();
            services.AddScoped<IGetCategories, FetchService4CodeMap>();
            services.AddScoped<IGetCodeDetailService, FetchService4CodeMap>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=CodeMap}/{action=Index}/{id?}");
            });
        }
    }
}
