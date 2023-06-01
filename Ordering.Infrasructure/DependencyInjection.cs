using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.Repositories;
using Ordering.Domain.Repositories.Base;
using Ordering.Infrasructure.Data;
using Ordering.Infrasructure.Repositories;
using Ordering.Infrasructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrasructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrasructure(this IServiceCollection services,IConfiguration configuration)
        {
            //services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
            //                                             ServiceLifetime.Singleton,
            //                                             ServiceLifetime.Singleton);
            services.AddDbContext<OrderContext>(options=>
                                options.UseSqlServer(
                                    configuration.GetConnectionString("OrderConnection"),
                                    b=>b.MigrationsAssembly(typeof(OrderContext).Assembly.FullName)),ServiceLifetime.Singleton);
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
