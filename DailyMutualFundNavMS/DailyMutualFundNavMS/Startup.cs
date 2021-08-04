using DailyMutualFundNavMS.Interface;
using DailyMutualFundNavMS.Loggers;
using DailyMutualFundNavMS.Models;
using DailyMutualFundNavMS.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DailyMutualFundNavMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContextPool<DailyNavDetailContext>(

            options => options.UseSqlServer(Configuration.GetConnectionString("DailyNavDBConnection")));

            services.AddScoped<IMutualFundRepo, MutualFundRepo>();
            services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DailyMutualFundNavMS", Version = "v1" });
            });
            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DailyMutualFundNavMS v1"));
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
