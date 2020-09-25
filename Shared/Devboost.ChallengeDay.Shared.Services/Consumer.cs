using Confluent.Kafka;
using Devboost.ChallengeDay.Shared.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Shared.Services
{
    public class Consumer : ServiceBase, IConsumer
    {
        private const string StartProcess = "IniciaProcesso";

        public Consumer(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<string>> ExecuteAsync(CancellationToken stopingToken, string topicName)
        {
            var result = new List<string>();

            var config = new ConsumerConfig
            {
                BootstrapServers = _kafcaConnection,
                GroupId = $"{topicName}-group-0",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe(topicName);

            try
            {
                var message = StartProcess;
                while (!string.IsNullOrEmpty(message))
                {
                    var cr = consumer.Consume(stopingToken);
                    message = cr.Message.Value;
                    result.Add(message);
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
            }

            return result;
        }
    }
}
