namespace ClusterService.Client.DTOs;

[DataContract]
public class LeaseRequest
{
    public LeaseRequest()
    {
        SourceIdentification = string.Empty;
    }

    public LeaseRequest(string sourceIdentification, TimeSpan wantedGracePeriod, Guid leaseToken)
    {
        SourceIdentification = sourceIdentification;
        WantedGracePeriod = wantedGracePeriod;
        LeaseToken = leaseToken;
    }

    [DataMember(Order = 1)] public string SourceIdentification { get; set; }
    [DataMember(Order = 2)] public TimeSpan WantedGracePeriod { get; set; }
    [DataMember(Order = 3)] public Guid LeaseToken { get; set; }
}
