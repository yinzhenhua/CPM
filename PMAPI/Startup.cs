using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PMRepository;
using PMRepository.IRepositories;
using PMRepository.Repositories;
using PMService.Interfaces.CodeMapServices;
using PMService.Services.CodeMapServices;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace PMAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Default"),
                                  b=>b.MigrationsAssembly("PMAPI"));
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
