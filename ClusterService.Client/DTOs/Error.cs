namespace ClusterService.Client.DTOs;

[DataContract]
public class Error
{
    public Error()
    {
        Message = string.Empty;
        Details = Array.Empty<string>();
    }

    public Error(string message, IEnumerable<string>? details)
    {
        Message = message;
        Details = details?.ToArray() ?? Array.Empty<string>();
    }

    [DataMember(Order = 1)] public string Message { get; set; }
    [DataMember(Order = 2)] public string[] Details { get; set; }
}