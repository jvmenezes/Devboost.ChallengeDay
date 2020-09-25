using Devboost.ChallengeDay.Domain.ENUMs;
using System;

namespace Devboost.ChallengeDay.Domain.Entities
{
    public class Transacao : Entity
    {
        public int IDUser { get; set; } = 1;

        public float Valor { get; set; }
        public EnumTipoAcao acao { get; set; }

        public DateTime DataHora { get; set; } = DateTime.Now;
    }
}
