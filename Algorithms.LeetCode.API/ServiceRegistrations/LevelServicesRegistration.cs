using Algorithms.LeetCode.API.DataManager;
using Algorithms.LeetCode.API.DataManager.Interfaces;

namespace Algorithms.LeetCode.API.ServiceRegistrations
{
    public static class LevelServicesRegistration
    {
        public static IServiceCollection AddLevelServices(this IServiceCollection services)
        {
            services.AddScoped<IEasyLevel, EasyLevel>();
            return services;
        }
    }
}
