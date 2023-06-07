using Algorithms.Codewars.API.DataManager;
using Algorithms.Codewars.API.DataManager.Interfaces;

namespace Algorithms.Codewars.API.ServiceRegistrations
{
    public static class LevelServicesRegistration
    {
        public static IServiceCollection AddLevelServices(this IServiceCollection services)
        {
            services.AddScoped<INoviceLevel, NoviceLevel>();
            return services;
        }
    }
}
