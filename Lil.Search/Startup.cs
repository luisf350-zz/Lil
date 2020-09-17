using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Lil.Search.Interfaces;
using Lil.Search.Services;

namespace Lil.Search
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
            services.AddControllers();

            // Services injection
            services.AddSingleton<ICustomersService, CustomersService>();
            services.AddSingleton<IProductsService, ProductsService>();
            services.AddSingleton<ISalesService, SalesService>();

            // Add ttp Client Factory per Project
            services.AddHttpClient("customersServices", c =>
            {
                c.BaseAddress = new Uri(Configuration["Services:Customers"]);
            });
            services.AddHttpClient("productsServices", c =>
            {
                c.BaseAddress = new Uri(Configuration["Services:Products"]);
            });
            services.AddHttpClient("salesServices", c =>
            {
                c.BaseAddress = new Uri(Configuration["Services:Sales"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
