using Devboost.ChallengeDay.Domain.ENUMs;

namespace Devboost.ChallengeDay.Domain.Entities
{
    public class Transacao : Entity
    {
        public float Valor { get; set; }
        public TipoAcao Acao { get; set; }
    }
}
