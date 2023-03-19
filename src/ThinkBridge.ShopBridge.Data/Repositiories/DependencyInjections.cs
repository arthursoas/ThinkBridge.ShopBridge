using Microsoft.Extensions.DependencyInjection;

namespace ThinkBridge.ShopBridge.Data.Repositiories
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();

            return services;
        }
    }
}
