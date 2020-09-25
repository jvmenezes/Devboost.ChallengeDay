using Devboost.ChallengeDay.Domain.DTOs;
using Devboost.ChallengeDay.Domain.Entities;
using Devboost.ChallengeDay.Domain.Interfaces.Commands;
using Devboost.ChallengeDay.Domain.Services;
using ServiceStack;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Application.Commands
{
    public class TransacaoCommand : ITransacaoCommand
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoCommand(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        public Task AddProducer(TransacaoDTO transacao)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddReal(TransacaoDTO transacao)
        {
            var model = transacao.ConvertTo<TransacaoModel>();

            _transacaoService.add
        }
    }
}