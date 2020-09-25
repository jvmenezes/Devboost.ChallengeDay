using Devboost.ChallengeDay.Domain.ENUMs;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Devboost.ChallengeDay.Domain.Entities
{
    public class Entity
    {
        [BsonId]
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}