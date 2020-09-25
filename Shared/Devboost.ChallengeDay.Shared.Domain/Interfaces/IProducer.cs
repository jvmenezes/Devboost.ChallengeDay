using Confluent.Kafka;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Shared.Domain.Interfaces
{
    public interface IProducer
    {
        Task<DeliveryResult<Null, string>> SendDataAsync(string topic, string message);
    }
}
