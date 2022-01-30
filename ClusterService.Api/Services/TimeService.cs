using ClusterService.Domain.Services;

namespace ClusterService.Api.Services
{
    public class TimeService : ITimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
