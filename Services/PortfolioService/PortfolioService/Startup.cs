using PortfolioService.Persistence.Interfaces;
using PortfolioService.Service;
using PortfolioService.Service.Interfaces;
using PriceService.Service;
using Redis.Interfaces;
using StackExchange.Redis;

namespace PortfolioService
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
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IRedisService, RedisService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
