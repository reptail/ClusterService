namespace ClusterService.Client.DTOs;

[DataContract]
public class Lease
{
    public Lease()
    {
        System = string.Empty;
        AquiredBy = string.Empty;
    }

    public Lease(int leaseId, string system, DateTime aquiredAtUtc, string aquiredBy, DateTime expiresAt, TimeSpan gracePeriod)
    {
        LeaseId = leaseId;
        System = system;
        AquiredAtUtc = aquiredAtUtc;
        AquiredBy = aquiredBy;
        ExpiresAt = expiresAt;
        GracePeriod = gracePeriod;
    }

    [DataMember(Order = 1)] public int LeaseId { get; set; }
    [DataMember(Order = 2)] public string System { get; set; }
    [DataMember(Order = 3)] public DateTime AquiredAtUtc { get; set; }
    [DataMember(Order = 4)] public string AquiredBy { get; set; }
    [DataMember(Order = 5)] public DateTime ExpiresAt { get; set; }
    [DataMember(Order = 6)] public TimeSpan GracePeriod { get; set; }
}
