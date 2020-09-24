using Devboost.ChallengeDay.Domain.DTOs;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Domain.Interfaces.Commands
{
    public interface ITransacaoCommand
    {
        Task AddProducer(TransacaoDTO transacao);
        Task AddReal(TransacaoDTO transacao);
    }
}