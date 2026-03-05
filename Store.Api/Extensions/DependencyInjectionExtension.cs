using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces;
using Store.Application.Services;
using Store.Domain.Ports;
using Store.Infrastructure;
using Store.Infrastructure.Adapters;

namespace Store.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            
            return services;
        }
    }
}
