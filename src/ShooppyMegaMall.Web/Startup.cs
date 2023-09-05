using ShoppiteVendor.Application.Interfaces;
using ShoppiteVendor.Application.Services;
using ShoppiteVendor.Core;
using ShoppiteVendor.Core.Interfaces;
using ShoppiteVendor.Infrastructure.Logging;
using ShoppiteVendor.Infrastructure.Data;
using ShoppiteVendor.Infrastructure.Repository;
using ShoppiteVendor.Web.HealthChecks;
using ShoppiteVendor.Web.Interfaces;
using ShoppiteVendor.Web.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppiteVendor.Core.Repositories;
using ShoppiteVendor.Core.Repositories.Base;
using ShoppiteVendor.Core.Configuration;
using ShoppiteVendor.Infrastructure.Repository.Base;

namespace ShoppiteVendor.Web
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
            // ShoppiteVendor dependencies
            ConfigureShoppiteVendorServices(services);            

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddRazorPages();
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
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        private void ConfigureShoppiteVendorServices(IServiceCollection services)
        {
            // Add Core Layer
            services.Configure<ShoppiteVendorSettings>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            // Add Application Layer
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            services.AddScoped<IIndexPageService, IndexPageService>();
            services.AddScoped<IProductPageService, ProductPageService>();
            services.AddScoped<ICategoryPageService, CategoryPageService>();

            // Add Miscellaneous
            services.AddHttpContextAccessor();
            services.AddHealthChecks()
                .AddCheck<IndexPageHealthCheck>("home_page_health_check");
        }

        public void ConfigureDatabases(IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<ShoppiteVendorContext>(c =>
                c.UseInMemoryDatabase("ShoppiteVendorConnection"));

            //// use real database
            //services.AddDbContext<ShoppiteVendorContext>(c =>
            //    c.UseSqlServer(Configuration.GetConnectionString("ShoppiteVendorConnection")));
        }
    }
}
