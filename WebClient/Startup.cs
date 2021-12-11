using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Radzen;
using WebClient.Authentication;
using WebClient.Data;
using WebClient.Data.Impl;

namespace WebClient
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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
            services.AddScoped<IMenusService, MenusWebService>();
            services.AddScoped<IMenuItemsService, MenuItemsWebService>();
            services.AddScoped<IMenuItemsSelectionsService, MenuItemsSelectionsWebService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITableBookingService, TableBookingService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddScoped<IAccountService, AccountWebService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            
            services.AddAuthorization(options => {
                options.AddPolicy("Employee",  a => 
                    a.RequireAuthenticatedUser().RequireClaim("Role", Role.Employee.ToString()));
            
                options.AddPolicy("Customer",  a => 
                    a.RequireAuthenticatedUser().RequireClaim("Role", Role.Customer.ToString()));

            });
            
            services.AddScoped<IAccountService, AccountWebService>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}