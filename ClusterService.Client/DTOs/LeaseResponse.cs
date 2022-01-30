namespace ClusterService.Client.DTOs;

[DataContract]
public class LeaseResponse
{
    public LeaseResponse() { }

    public LeaseResponse(int leaseId, DateTime expiresAtUtc)
    {
        LeaseId = leaseId;
        ExpiresAtUtc = expiresAtUtc;
    }

    [DataMember(Order = 1)] public int LeaseId { get; set; }
    [DataMember(Order = 2)] public DateTime ExpiresAtUtc { get; set; }
}