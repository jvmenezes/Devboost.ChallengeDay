using Devboost.ChallengeDay.Domain.DTOs;
using Devboost.ChallengeDay.Shared.Domain.Constants;
using Devboost.ChallengeDay.Shared.Domain.Interfaces;
using Newtonsoft.Json;
using Devboost.ChallengeDay.Domain.Entities;
using Devboost.ChallengeDay.Domain.Interfaces.Commands;
using Devboost.ChallengeDay.Domain.Services;
using ServiceStack;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Application.Commands
{
    public class TransacaoCommand : ITransacaoCommand
    {
        private readonly IProducer _producer;
        private readonly ITransacaoService _transacaoService;

        public TransacaoCommand(IProducer producer, ITransacaoService transacaoService)
        {
            _producer = producer;
            _transacaoService = transacaoService;
        }

        public async Task AddConsumer(TransacaoDTO transacao)  
        {
            var output = JsonConvert.SerializeObject(transacao);
            await _producer.SendDataAsync(ProjectConsts.TOPIC_NAME, output);     
        }

        public async Task AddReal(TransacaoDTO transacao)
        {
            var model = transacao.ConvertTo<TransacaoModel>();

            await _transacaoService.EfetuarAcao(model);
        }
    }
}