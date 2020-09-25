using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Devboost.ChallengeDay.Shared.Domain.Interfaces
{
    public interface IConsumer
    {
        Task<List<string>> ExecuteAsync(CancellationToken stopingToken, string topicName);

    }
}
