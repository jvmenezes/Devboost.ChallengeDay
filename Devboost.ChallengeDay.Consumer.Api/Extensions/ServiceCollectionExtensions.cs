
using Devboost.ChallengeDay.Consumer.Domain.Interfaces;
using Devboost.ChallengeDay.Consumer.Services;
using Devboost.ChallengeDay.Shared.Domain.Interfaces;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devboost.ChallengeDay.Consumer.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHangfireService(this IServiceCollection services)
        {
            services.AddHangfire(config => config.UseMemoryStorage());
        }

        public static void AddSingletonServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddSingleton<IConsumer, Shared.Services.Consumer>();
            services.AddSingleton<IProcessorQueue, ProcessorQueue>();
        }
    }
}
