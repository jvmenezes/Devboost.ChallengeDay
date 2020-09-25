using Devboost.ChallengeDay.Consumer.Domain.Interfaces;
using Devboost.ChallengeDay.Shared.Domain.Interfaces;
using Hangfire;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Consumer.Services
{
    public class ProcessorQueue : IProcessorQueue
    {
        private readonly IConsumer _consumer;
        private readonly IConfiguration _configuration;
        private readonly string _urlBase;

        public ProcessorQueue(IConsumer consumer, IConfiguration configuration)
        {
            _consumer = consumer;
            _configuration = configuration;
            _urlBase = configuration.GetSection("urlBase").Value;

        }

        [JobDisplayName("TopicName: {0}")]
        public async Task ProcessorQueueAsync(string topicName)
        {
            using var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            var messages = await _consumer.ExecuteAsync(cancellationToken.Token, topicName);
            
            foreach (var message in messages)
            {
                using var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(_urlBase)
                };
             

                var request = new StringContent(message, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/transacao", request);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error to post pedido");
                }
            }
        }


    }

}
