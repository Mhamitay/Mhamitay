using EasyDine.Application;
using EasyDine.Persistance;
using EasyDine.Persistance.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EasyDineCoreApi
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

            //services.AddMvc();
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddSingleton<IInMemoryDBContext, InMemoryDBContext>();
            services.AddControllers();
            
            //services.AddCors(setup =>
            //{
            //    // Set up our policy name
            //    setup.AddPolicy("AllowRoundTheCode", policy =>
            //    {
            //        policy.WithOrigins(new string[] { "http://localhost:23657" }).AllowAnyMethod().AllowAnyHeader().AllowCredentials(); // Allow everyone from https://www.roundthecode.com (you're very kind)
            //    });
            //});
            services.AddCors(); // Make sure you call this previous to AddMvc
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
         }
    }
}
