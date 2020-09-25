using Devboost.ChallengeDay.Domain.Interfaces.Queries;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Application.Queries
{
    public class TransacaoQuery : ITransacaoQuery
    {
        public async Task<float> GetSaldo()
        {
            return 0;
        }
    }
}
