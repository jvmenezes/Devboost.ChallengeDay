using Devboost.ChallengeDay.Domain.DTOs;
using Devboost.ChallengeDay.Shared.Domain.Constants;
using Devboost.ChallengeDay.Shared.Domain.Interfaces;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Application.Commands
{
    public class TransacaoCommand
    {

        private readonly IProducer _producer;

        public TransacaoCommand(IProducer producer)
        {
            _producer = producer;
        }

        public async Task AddConsumer(TransacaoDTO transacao)  
        {
            var output = JsonConvert.SerializeObject(transacao);
            await _producer.SendDataAsync(ProjectConsts.TOPIC_NAME, output);
        }
    }
}