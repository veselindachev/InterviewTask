using Microsoft.EntityFrameworkCore;
using OrderService.Persistence;
using OrderService.Persistence.Interfaces;
using OrderService.Service;
using PriceService.Service;
using PriceService.Service.Interfaces;
using Redis.Interfaces;
using StackExchange.Redis;

namespace OrderService
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
            services.AddSingleton<IConnectionMultiplexer>(provider =>
            {
                var configuration = ConfigurationOptions.Parse(Configuration.GetConnectionString("RedisConnection"));
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddScoped<IOrderProcessor, OrderProcessor>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRedisService, RedisService>();
            services.AddScoped<IPriceServiceClient, PriceServiceClient>();
            services.AddDbContext<OrderDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

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
