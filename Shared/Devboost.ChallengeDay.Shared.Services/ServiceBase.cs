using Microsoft.Extensions.Configuration;

namespace Devboost.ChallengeDay.Shared.Services
{
    public class ServiceBase
    {
        protected readonly string _kafcaConnection;
        public ServiceBase(IConfiguration configuration)
        {
            _kafcaConnection = configuration.GetConnectionString("kafkaConnection");
        }
    }
}
