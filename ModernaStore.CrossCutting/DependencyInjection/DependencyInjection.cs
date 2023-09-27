using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModernStore.Data.DataContext;
using ModernStore.Data.Repositories;
using ModernStore.Data.Transactions;
using ModernStore.Domain.Handlers;
using ModernStore.Domain.Repositories;

namespace ModernStore.CrossCutting.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories();

            services
                .AddDbContextPool<ModernStoreDataContext>(opts => opts
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
                .UseSqlServer(configuration
                .GetConnectionString("SQLConnection"), b => b
                .MigrationsAssembly(typeof(ModernStoreDataContext).Assembly.FullName)));


            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IUow), typeof(Uow));
            services.AddScoped(typeof(CustomerCommandHandler), typeof(CustomerCommandHandler));
            services.AddScoped(typeof(OrderCommandHandler), typeof(OrderCommandHandler));





            return services;
        }

    }
}
