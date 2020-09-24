using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devboost.ChallengeDay.IoC
{
    public static class ResolveDependencies
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

    }
}
