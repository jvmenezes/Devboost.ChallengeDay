using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Devboost.ChallengeDay.Consumer.Api.Filter
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
