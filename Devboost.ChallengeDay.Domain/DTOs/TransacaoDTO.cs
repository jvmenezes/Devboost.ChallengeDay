using Devboost.ChallengeDay.Domain.ENUMs;

namespace Devboost.ChallengeDay.Domain.DTOs
{
    public class TransacaoDTO
    {
        public float Valor { get; set; }
        public TipoAcao acao { get; set; }
    }
}