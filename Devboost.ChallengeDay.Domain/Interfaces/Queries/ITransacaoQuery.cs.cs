using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Domain.Interfaces.Queries
{
    public interface ITransacaoQuery
    {
        Task<float> GetSaldo();
    }
}