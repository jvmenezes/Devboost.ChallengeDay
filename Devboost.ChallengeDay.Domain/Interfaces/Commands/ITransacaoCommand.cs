using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Domain.Interfaces.Commands
{
    public interface ITransacaoCommand
    {
        public async Task Add();
    }
}