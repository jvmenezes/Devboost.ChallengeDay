using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Consumer.Domain.Interfaces
{
    public interface IProcessorQueue
    {
        Task ProcessorQueueAsync(string topicName);
    }
}
