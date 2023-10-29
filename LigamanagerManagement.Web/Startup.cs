using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Web.Models;
using LigaManagerManagement.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LigaManagerManagement.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Identity.Application")
                .AddCookie();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddAutoMapper(typeof(EmployeeProfile));

            services.AddHttpClient<ISpieltagService, SpieltagService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44379/");
            });
                       

            services.AddHttpClient<IVereineService, VereineService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44379/");
            });

            services.AddHttpClient<ITabelleService, TabelleService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44379/");
            });
            services.AddHttpClient<ISaisonenService, SaisonenService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44379/");
            });
            services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44379/");
            });
            services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44379/");
            });

            services.AddHttpClient<ILigaService, LigaService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44379/");
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
