using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShooppyMegaMall.Core.Configuration;
using ShooppyMegaMall.Core.Interfaces;
using ShooppyMegaMall.Core.Repositories;
using ShooppyMegaMall.Core.Repositories.Base;
using ShooppyMegaMall.Infrastructure.Logging;
using ShooppyMegaMall.Infrastructure.Repository;
using ShooppyMegaMall.Infrastructure.Repository.Base;
using ShooppyMegaMall.Web.HealthChecks;
using ShooppyMegaMall.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ShooppyMegaMall.Application.Interfaces;
using ShooppyMegaMall.Application.Services;
using ShooppyMegaMall.UI.Interfaces;
using ShooppyMegaMall.UI.Services;
using ShooppyMegaMall.Application.Services;
using ShooppyMegaMall.Application.Interfaces;
using ShooppyMegaMall.Web.Interfaces;
using ShooppyMegaMall.Web.Services;
using Microsoft.AspNetCore.Identity;
using ShooppyMegaMall.UI.Extensions;
using System.Text;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ShooppyMegaMall.UI.Helpers;

namespace ShooppyMegaMall.UI
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
            services.AddControllersWithViews();
            ConfigureShooppyMegaMallServices(services);
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddHttpContextAccessor();
            services.Configure<HtmlHelperOptions>(o => o.ClientValidationEnabled = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCookiePolicy();
            app.UseSession();

            app.Use(async (context, next) =>
            {
                var JWToken = context.Session.GetString("JWToken");

                if (!string.IsNullOrEmpty(JWToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
                }
                await next();
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureShooppyMegaMallServices(IServiceCollection services)
        {
            // Add Core Layer
            services.Configure<ShooppyMegaMallSettings>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IWishlistRepository, WishlistRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMyAccountRepository, MyAccountRepository>();
            services.AddScoped<IProductDetailRepsitory, ProductDetailRepository>();
            services.AddScoped<IAuthenticationsRepository, AuthenticatiosRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICommonRepository, CommonRepository>();

            // Add Application Layer
            services.AddScoped<IBrandServices, BrandServices>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductDetailServices, ProductDetilServices>();
            services.AddScoped<IAuthenticationsService, AuthenticationsService>();
            services.AddScoped<ICartServices, CartServices>();
            services.AddScoped<IWishlistService, WishlistService>();
            services.AddScoped<IMyAccountService, MyAccountService>();

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IBrandPageServices, BrandPageServices>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<ICommonHelper, CommonHelper>();
            services.AddScoped<ICategoryPageService, CategoryPageService>();
            services.AddScoped<IproductDetailPageServices, ProductDetailPageServices>();
            services.AddScoped<ICartPageServices, CartPageServices>();
            services.AddScoped<IAuthenticationsPageService, AuthenticationPageService>();
            services.AddScoped<IWishlistPageService, WishlistPageService>();
            services.AddScoped<IMyAccountPageService, MyAccountPageService>();

            // Add Miscellaneous
            services.AddHttpContextAccessor();
            services.AddHealthChecks()
                .AddCheck<IndexPageHealthCheck>("home_page_health_check");
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ShooppyMegaMall_masterContext>();

            SiteKeys.Configure(Configuration.GetSection("AppSettings"));
            var key = Encoding.ASCII.GetBytes(SiteKeys.Token);

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(token =>
               {
                   token.RequireHttpsMetadata = false;
                   token.SaveToken = true;
                   token.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = true,
                       ValidIssuer = SiteKeys.WebSiteDomain,
                       ValidateAudience = true,
                       ValidAudience = SiteKeys.WebSiteDomain,
                       RequireExpirationTime = true,
                       ValidateLifetime = true,
                       ClockSkew = TimeSpan.Zero
                   };
               });
        }
        public void ConfigureDatabases(IServiceCollection services)
        {
            // use in-memory database
            //services.AddDbContext<ShooppyMegaMallContext>(c =>
            //    c.UseInMemoryDatabase("ShooppyMegaMallConnection"));

            //// use real database
            services.AddDbContext<ShooppyMegaMall_masterContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("ShooppyMegaMallConnection")));
        }
    }
}
