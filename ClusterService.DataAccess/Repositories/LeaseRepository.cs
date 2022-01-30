namespace ClusterService.DataAccess.Repositories
{
    public class LeaseRepository : ILeaseRepository
    {
        private readonly SqlConnection _sqlConnection;

        public LeaseRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<dto.Lease> GetLatestAsync(string system)
        {
            dto.Lease? latest = await _sqlConnection.QuerySingleOrDefaultAsync<dto.Lease?>(
                sql: Scripts.SelectLatestLease,
                param: new { system }
            );

            if (latest is null)
                throw new NotFoundException($"No latest Lease was found for '{system}'!");

            return latest;
        }
    }
}
