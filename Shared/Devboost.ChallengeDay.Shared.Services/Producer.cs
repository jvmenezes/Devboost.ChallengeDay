using Confluent.Kafka;
using Devboost.ChallengeDay.Shared.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Shared.Services
{
    public class Producer : ServiceBase, IProducer
    {
        public Producer(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<DeliveryResult<Null, string>> SendDataAsync(string topic, string message)
        {
            string bootstrapServers = _kafcaConnection;
            var nomeTopic = topic;


            var config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();
            return await producer.ProduceAsync(
                nomeTopic,
                new Message<Null, string>
                { Value = message });
        }

    }
}

