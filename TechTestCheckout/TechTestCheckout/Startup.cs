using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ServiceLayer.Repositories;
using ServiceLayer.Repositories.Interfaces;
using ServiceLayer.Repositories.SpecialOffers;
using ServiceLayer.Repositories.SpecialOffers.Interfaces;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.Services.SpecialOffers;
using ServiceLayer.Services.SpecialOffers.Interfaces;

namespace TechTestCheckout
{
    public class Startup
    {
        private readonly string homeError = "/Home/Error";
        private readonly string apiTitle = $"Sorted ! Tech Test Checkout Kata API";
        private readonly string apiVersion = "v1";
        private string apiSwaggerUrl = "/swagger/v1/swagger.json";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(apiVersion, new OpenApiInfo { Title = apiTitle, Version = apiVersion });
            });

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ICheckoutRepository, CheckoutRepository>();
            // Special Offers
            services.AddScoped<ISpecialOfferItemService, SpecialOfferItemService>();
            services.AddScoped<ISpecialOfferItemRepository, SpecialOfferItemRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c =>
                {
                    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                    apiSwaggerUrl = $"{swaggerJsonBasePath}{apiSwaggerUrl}";
                    c.SwaggerEndpoint(apiSwaggerUrl, apiTitle);
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
