using Devboost.ChallengeDay.Domain.ENUMs;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Devboost.ChallengeDay.Domain.Entities
{
    public class TransacaoModel
    {
        [BsonId]
        public Guid Id { get; set; }

        protected TransacaoModel()
        {
            Id = Guid.NewGuid();
        }

        public int IDUser { get; set; } = 1;

        public float Valor { get; set; }
        public EnumTipoAcao acao { get; set; }        
    }
}