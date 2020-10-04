using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Persistence.Contexts;
using Supermarket.API.Persistence.Repositories;
using Supermarket.API.Services;
 
namespace Supermarket.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

        // This method gets called by th runtime. Use this method to add services to the container.
        // Adding services to the service container makes them available within the app and connect to database
        public  void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
         
            // connect to database :- 
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-OC242A6; Database=Mercury; Trusted_Connection=True;MultipleActiveResultSets=True");
            });
            // services.AddDbContext<AppDbContext>(
            //     options => { options.UseMySql("server=localhost;port=3306; database=Mercury; user=root; pwd=123123;"); });
              // add application services :- 
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // The Configure method is used to specify how the app responds to HTTP requests
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
            // redirects HTTP requests to HTTPS.
            app.UseHttpsRedirection();
            // route statice file (html/css/js/..)(under webroot) and didnt continue to next middleware.
            app.UseStaticFiles();

           app.UseRouting();

            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // app.UseEndpoints(endpoint => endpoint.MapControllerRoute(
            //     name: "default" ,
            //     pattern: "{controller=Categories}/{action=Index}/{id?}"
            //     ));

            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(
            //         name: "default",
            //         template: "{Controller=Categories}");
            // });




        }
    }
}
