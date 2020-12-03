using ERPProject.Data;
using ERPProject.Data.Repositories;
using ERPProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace ERPProject
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
            services.AddDbContext<ERPContext>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ERPContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<Employee, ERPContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDatabaseDeveloperPageExceptionFilter();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            #region register repositories
            services.AddScoped<ProductRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<OrderRepository>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();

                endpoints.MapGet("/Identity/Account/Register", context =>
                    Task.Factory.StartNew(() => context.Response.Redirect("/", true, true)));
                endpoints.MapPost("/Identity/Account/Register", context =>
                    Task.Factory.StartNew(() => context.Response.Redirect("/", true, true)));
                endpoints.MapGet("/Identity/Account/Manage/ChangePassword", context =>
                    Task.Factory.StartNew(() => context.Response.Redirect("/Identity/Account/Manage", true, true)));
                endpoints.MapPost("/Identity/Account/Manage/ChangePassword", context =>
                    Task.Factory.StartNew(() => context.Response.Redirect("/Identity/Account/Manage", true, true)));
                endpoints.MapGet("/Identity/Account/Manage/TwoFactorAuthentication", context =>
                    Task.Factory.StartNew(() => context.Response.Redirect("/Identity/Account/Manage", true, true)));
                endpoints.MapPost("/Identity/Account/Manage/TwoFactorAuthentication", context =>
                    Task.Factory.StartNew(() => context.Response.Redirect("/Identity/Account/Manage", true, true)));
                endpoints.MapGet("/Identity/Account/Manage/PersonalData", context =>
                    Task.Factory.StartNew(() => context.Response.Redirect("/Identity/Account/Manage", true, true)));
                endpoints.MapPost("/Identity/Account/Manage/PersonalData", context =>
                    Task.Factory.StartNew(() => context.Response.Redirect("/Identity/Account/Manage", true, true)));
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
