using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EntityFramework;
using ShopApp.DataAccess.Concrete.EntityFramework.Seed;
using ShopApp.DataAccess.Concrete.Memory;
using ShopApp.WebUI.Identity;
using ShopApp.WebUI.Middlewares;

namespace ShopApp.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true; // sayısaıl değer
                options.Password.RequireLowercase = true; // küçük karakter
                options.Password.RequiredLength = 6; // minumum kaç karakter
                options.Password.RequireNonAlphanumeric = true; // Alfanumerik zorunlu
                options.Password.RequireUppercase = true; // büyük karakter

                options.Lockout.MaxFailedAccessAttempts = 5; // kaç kere yanlış girme hakkı olsun
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // 5 dk kullanııcı kilitlendi
                options.Lockout.AllowedForNewUsers = true; // yeni kullanıcı için kilit işlemi aktif olsun

                options.User.AllowedUserNameCharacters = ""; // Kullanıcı adında geçerli olan karakterleri belirtiyoruz.
                options.User.RequireUniqueEmail = false; // aynı mail adresi ile üyelikoluşmaz
                options.SignIn.RequireConfirmedEmail = false; // mail adresine onay gidecek
                options.SignIn.RequireConfirmedPhoneNumber = false; // telefonla onaylamak için
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true; //default 20 dk cookie süresi 
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".ShopApp.Security.Cookie"
                };
            });

            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed() ;
            }

            app.UseStaticFiles();
            app.CustomStaticFiles();
            app.UseAuthentication();
            app.UseMvc( routes =>
            {
                routes.MapRoute(
                   name: "adminProducts",
                   template: "admin/products",
                   defaults: new { controller = "Admin", action = "ProductList" }
                   );
                routes.MapRoute(
                   name: "adminProducts",
                   template: "admin/products/{id?}",
                   defaults: new { controller = "Admin", action = "EditProduct" }
                   );
                routes.MapRoute(
                    name: "products",
                    template:"products/{category?}",
                    defaults: new { controller = "Shop", action = "List" }
                    );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
