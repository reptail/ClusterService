namespace ClusterService.Domain.Repositories;

public interface ILeaseRepository
{
    Task<dto.Lease> GetLatestAsync(string system);
}
