using Microsoft.Extensions.DependencyInjection;
using Repository.Implement;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Modules
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddScoped<ICartRepo, CartRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IImageRepo, ImageRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOriginRepo, OriginRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IVoucherRepo, VoucherRepo>();

            return services;
        }
    }
}
