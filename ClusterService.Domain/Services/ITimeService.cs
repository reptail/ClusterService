namespace ClusterService.Domain.Services;

public interface ITimeService
{
    DateTime UtcNow { get; }
}
