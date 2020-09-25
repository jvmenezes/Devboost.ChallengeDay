using Devboost.ChallengeDay.Domain.Entities;
using Devboost.ChallengeDay.Domain.ENUMs;
using Devboost.ChallengeDay.Domain.Interfaces.Repositories;
using Devboost.ChallengeDay.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.DomainServices.Implementation.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly IRepository<Transacao> _repositoryTransacao;

        public TransacaoService(IRepository<Transacao> repositoryTransacao)
        {
            _repositoryTransacao = repositoryTransacao;
        }

        public async Task EfetuarAcao(Transacao model) 
        {
            var saldo = await _repositoryTransacao.ObterPor(model => model.IDUser == 1);

            if (saldo != null)
            {
                var oneS = saldo.FirstOrDefault();

                if (model.acao.Equals(EnumTipoAcao.Deposito))
                    oneS.Valor += model.Valor;
                else
                    oneS.Valor -= model.Valor;

                await _repositoryTransacao.Atualizar(model);
            }
            else
            {
                await _repositoryTransacao.Adicionar(model);
            }
        }
    }
}