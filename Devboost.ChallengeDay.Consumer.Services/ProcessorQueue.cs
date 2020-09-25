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
        private const string _urlTransacao = "/api/transacao";
        private readonly string _urlBase;
        private const string URL_API = "UrlApi";
        private const string MediaType = "application/json";

        public ProcessorQueue(IConsumer consumer, IConfiguration configuration)
        {
            _consumer = consumer;
            _urlBase = configuration.GetSection(URL_API).Value;

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
                var request = new StringContent(message, Encoding.UTF8, MediaType);
                var response = await httpClient.PostAsync(_urlTransacao, request);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error to post transação");
                }
            }
        }
    }
}