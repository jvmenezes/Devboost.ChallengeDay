using Devboost.ChallengeDay.Domain.Entities;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Domain.Services
{
    public interface ITransacaoService
    {
        Task EfetuarAcao(Transacao model);
    }
}