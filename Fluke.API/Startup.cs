using Fluke.API.Binders;
using Fluke.API.Models.Options;
using Fluke.API.Repository;
using Fluke.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fluke.API
{
    public class Startup
    {
        readonly string AllowOriginsName = "_flukeAllowOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: AllowOriginsName,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5000");
                    }
                );
            });

            services.AddControllers(opts =>
            {
                opts.ModelBinderProviders.Insert(0, new FilterModelBinderProvider());
            });

            // Custom configuration
            var config = new EONETConfiguration();
            Configuration.Bind(EONETConfiguration.EONET, config);
            services.AddSingleton(config);

            // Custom services
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, EventService>();
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

            app.UseCors(AllowOriginsName);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
